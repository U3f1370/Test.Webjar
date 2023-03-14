using Common;
using Entities.Product;
using Infrastructure.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;
using Volo.Abp.DependencyInjection;

namespace Services.Product
{

    public class ProductService : IProductService, IScopedDependency
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<ProductCategory> _productCategory;
        private readonly DbSet<ProductAdditive> _productAdditive;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _productCategory = _uow.Set<ProductCategory>();
            _productAdditive = _uow.Set<ProductAdditive>();
        }

        #region Category
        public async Task<ServiceResult> CreateCategory(string Title, CancellationToken cancellationToken)
        {
            var exist = await _productCategory.FirstOrDefaultAsync(p => p.Title == Title);
            if (exist is not null)
                return new ServiceResult(true, ApiResultStatusCode.BadRequest, "This category has already been created");

            var category = new ProductCategory(Title);
            await _productCategory.AddAsync(category);
            var result = await _uow.SaveChangesAsync();
            if(result>0)
                return new ServiceResult(true, ApiResultStatusCode.Success);

            return new ServiceResult(true,ApiResultStatusCode.ServerError);
        }

        public async Task<ServiceResult<List<ProductCategoryVm>>> GetProductCategory(string? filter, CancellationToken cancellationToken)
        {
            var categorys = await _productCategory
                .Where(c => !string.IsNullOrEmpty(filter)?c.Title.Contains(filter):true)
                .Select(c=> new ProductCategoryVm
                {
                    Id =c.Id,
                    Title = c.Title,
                    CreatedDm = c.CreateDm,
                    LastUpdatedDm = c.LastUpdateDm
                })
                .ToListAsync();
            return new ServiceResult<List<ProductCategoryVm>>(true,ApiResultStatusCode.Success,categorys);
        }
        #endregion

        #region ProductAdditive
        public async Task<ServiceResult> CreateProductAdditive(int categoryId,string title,decimal price, CancellationToken cancellationToken)
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

        public async Task<ServiceResult<List<ProductAddivesVm>>> GetProductAdditive(string? title, string? catTitle,CancellationToken cancellationToken)
        {
            var query = _productAdditive
                .Include(a => a.ProductCategory)
                .AsQueryable();
            if (catTitle is not null)
                query = query.Where(a => a.ProductCategory.Title.Contains(catTitle));
            if(title is not null)
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
            return new ServiceResult<List<ProductAddivesVm>>(true,ApiResultStatusCode.Success,additives);
        }
        #endregion
    }
}
