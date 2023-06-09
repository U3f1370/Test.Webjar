﻿using Common;
using Entities.Product;
using Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.File;
using Services.Product.Shared.Product;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;
using Services.Product.Shared.ProductPrice;
using Services.Product.Shared.ProductPriceOption;
using System.Reflection.Metadata.Ecma335;
using Volo.Abp.DependencyInjection;

namespace Services.Product
{

    public class ProductService : IProductService, IScopedDependency
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        private readonly DbSet<Entities.Product.Product> _product;
        private readonly DbSet<ProductCategory> _productCategory;
        private readonly DbSet<ProductAdditive> _productAdditive;
        private readonly DbSet<ProductPriceOption> _productPriceOption;
        private readonly DbSet<ProductPriceOptionValue> _optionValues;
        private readonly DbSet<ProductPriceHistory> _productPriceHistories;

        public ProductService(IUnitOfWork unitOfWork, IConfiguration configuration, IFileService fileService)
        {
            _uow = unitOfWork;
            _product = _uow.Set<Entities.Product.Product>();
            _productCategory = _uow.Set<ProductCategory>();
            _productAdditive = _uow.Set<ProductAdditive>();
            _productPriceOption = _uow.Set<ProductPriceOption>();
            _optionValues = _uow.Set<ProductPriceOptionValue>();
            _productPriceHistories = _uow.Set<ProductPriceHistory>();
            _configuration = configuration;
            _fileService = fileService;
        }
        #region Product
        public async Task<ServiceResult<List<ProductVm>>> GetProduct(string? productTitle,
            string? CategoryTitle, CancellationToken cancellationToken)
        {
            try
            {
                var query = _product
                    .Include(p => p.ProductCategory)
                    .Include(p => p.ProductPriceHistories)
                    .ThenInclude(p => p.ProductPriceOptionValues)
                    .ThenInclude(p => p.ProductPriceOption)
                    .Include(p => p.ProductToProductAdditive)
                    .ThenInclude(p => p.ProductAdditive)
                    .AsQueryable();

                if (productTitle is not null)
                    query = query.Where(p => p.Title.Contains(productTitle));

                if (CategoryTitle is not null)
                    query = query.Where(p => p.ProductCategory.Title.Contains(CategoryTitle));


                var Products = await query.Select(p => new ProductVm
                {
                    ProductTitle = p.Title,
                    ProductCategoryTitle = p.ProductCategory.Title,
                    prices = p.ProductPriceHistories.Any() ? p.ProductPriceHistories.Select(x => new Prices
                    {
                        Price = x.Price,
                        Inventory = x.Inventory,
                        DiscountPrice = x.DiscountPrice,
                        DiscountPriceExpireAt = x.DiscountPriceExpireAt,
                        Features = x.ProductPriceOptionValues.Select(h=>new Features
                        {
                            OptionTitle = h.ProductPriceOption.Name,
                            OptionValueTitle = h.Value
                        }).ToList()
                    }).ToList():default,
                    Additives = p.ProductToProductAdditive.Any() ? p.ProductToProductAdditive.Select(a => new Additives
                    {
                        Title = a.ProductAdditive.Title,
                        Price = a.ProductAdditive.Price,
                    }).ToList() : default,

                }).ToListAsync();


                return new ServiceResult<List<ProductVm>>(true, ApiResultStatusCode.Success, Products);
            }
            catch (Exception ex)
            {
                return new ServiceResult<List<ProductVm>>(false, ApiResultStatusCode.ServerError, null, ex.Message);
            }
        }
        public async Task<ServiceResult> CreateProduct(ProductModel model, CancellationToken cancellationToken)
        {
            var existCategory = await _productCategory.FirstOrDefaultAsync(c => c.Id.Equals(model.CategoryId));
            if (existCategory == null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Category is not exist");

            var existProduct = await _product.FirstOrDefaultAsync(p => p.Title == model.Title.Trim() && p.ProductCategoryId.Equals(model.CategoryId));
            if (existProduct is not null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Product has already been created");

            var product = new Entities.Product.Product(model.Title.Trim(), model.CategoryId);
            var pathImage = _configuration["SiteSettings:PathProductImage"];
            var resultFile = await _fileService.AddFile(model.Image, pathImage);
            var image = new ProductImage(resultFile.Data);
            product.Images = new List<ProductImage>() { image };

            await _product.AddAsync(product);
            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }
        #endregion

        #region Category
        public async Task<ServiceResult> CreateCategory(string Title, CancellationToken cancellationToken)
        {
            var exist = await _productCategory.FirstOrDefaultAsync(p => p.Title == Title);
            if (exist is not null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This category has already been created");

            var category = new ProductCategory(Title);
            await _productCategory.AddAsync(category);
            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }

        public async Task<ServiceResult<List<ProductCategoryVm>>> GetProductCategory(string? filter, CancellationToken cancellationToken)
        {
            var categorys = await _productCategory
                .Where(c => !string.IsNullOrEmpty(filter) ? c.Title.Contains(filter) : true)
                .Select(c => new ProductCategoryVm
                {
                    Id = c.Id,
                    Title = c.Title,
                    CreatedDm = c.CreateDm,
                    LastUpdatedDm = c.LastUpdateDm
                })
                .ToListAsync();
            return new ServiceResult<List<ProductCategoryVm>>(true, ApiResultStatusCode.Success, categorys);
        }
        #endregion

        #region ProductAdditive
        public async Task<ServiceResult> CreateProductAdditive(int categoryId, string title, decimal price, CancellationToken cancellationToken)
        {
            var existCategory = await _productCategory.FirstOrDefaultAsync(c => c.Id.Equals(categoryId));
            if (existCategory == null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Category is not exist");

            var exist = await _productAdditive
                .Where(a => a.ProductCategoryId.Equals(categoryId) && a.Title == title)
                .FirstOrDefaultAsync();
            if (exist is not null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Additive has already been created");

            var additive = new ProductAdditive(title, price, categoryId);
            await _productAdditive.AddAsync(additive);
            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }

        public async Task<ServiceResult<List<ProductAddivesVm>>> GetProductAdditive(string? title, string? catTitle, CancellationToken cancellationToken)
        {
            var query = _productAdditive
                .Include(a => a.ProductCategory)
                .AsQueryable();
            if (catTitle is not null)
                query = query.Where(a => a.ProductCategory.Title.Contains(catTitle));
            if (title is not null)
                query = query.Where(a => a.Title.Contains(title));

            var additives = await query
                .Select(a => new ProductAddivesVm
                {
                    Id = a.Id,
                    Title = a.Title,
                    CategoryTitle = a.ProductCategory.Title,
                    CreateDm = a.CreateDm,
                    LateUpdateDm = a.LastUpdateDm,
                }).ToListAsync();
            return new ServiceResult<List<ProductAddivesVm>>(true, ApiResultStatusCode.Success, additives);
        }
        #endregion

        #region ProductPriceOption
        public async Task<ServiceResult> CreateProductPriceOption(PriceOptionModel model, CancellationToken cancellationToken)
        {
            var existCategory = await _productCategory.FirstOrDefaultAsync(c => c.Id.Equals(model.CatId));
            if (existCategory == null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Category is not exist");

            var exist = await _productPriceOption
                .Where(a => a.ProductCategoryId.Equals(model.CatId) && a.Name == model.Name)
                .FirstOrDefaultAsync();
            if (exist is not null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This Option has already been created");

            var priceOption = new ProductPriceOption(model.CatId, model.Name);

            await _productPriceOption.AddAsync(priceOption);

            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }
        #endregion

        #region ProductPriceOptionValue
        public async Task<ServiceResult> CreatePriceOptionValue(PriceOptionValueModel model, CancellationToken cancellationToken)
        {
            // we should check option Id is Exists.Also we must check value so that it is not repeated
            var value = new ProductPriceOptionValue(model.Value, model.PriceOptionId);
            await _optionValues.AddAsync(value);

            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }
        #endregion

        #region ProductPrice
        public async Task<ServiceResult> CreateProductPrice(ProductPriceModel model, CancellationToken cancellationToken)
        {
            var productPrice = new ProductPriceHistory(model.Price, model.Inventory,
                model.DiscountPrice, model.DiscountPriceExpireAt, model.ProductId);

            if (model.OptionValuesIds != null && model.OptionValuesIds.Any())
            {
                //productPrice.ProductPriceOptionValues = new List<ProductPriceOptionValue>();
                var values = await _optionValues.Where(p => model.OptionValuesIds.Contains(p.Id)).ToListAsync();
                productPrice.ProductPriceOptionValues = values;
                //foreach (var item in model.OptionValuesIds)
                //{
                //    var option = await _optionValues.FindAsync(item).ConfigureAwait(false);
                //    productPrice.ProductPriceOptionValues.Add(option);
                //}
            }

            await _productPriceHistories.AddAsync(productPrice);

            var result = await _uow.SaveChangesAsync();
            if (result > 0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true, ApiResultStatusCode.ServerError);
        }
        #endregion
    }
}
