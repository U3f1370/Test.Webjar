﻿using Services.Product.Shared.Product;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;
using Services.Product.Shared.ProductPrice;
using Services.Product.Shared.ProductPriceOption;

namespace Services.Product
{
    public interface IProductService
    {
        #region Product
        Task<ServiceResult<List<ProductVm>>> GetProduct(string? productTitle,
            string? CategoryTitle, CancellationToken cancellationToken);
        Task<ServiceResult> CreateProduct(ProductModel model, CancellationToken cancellationToken);
        #endregion

        #region ProdcutCategory
        Task<ServiceResult> CreateCategory(string Title,CancellationToken cancellationToken);
        Task<ServiceResult<List<ProductCategoryVm>>> GetProductCategory(string? filter, CancellationToken cancellationToken);
        #endregion

        #region ProductAdditive
        Task<ServiceResult<List<ProductAddivesVm>>> GetProductAdditive(string? title, string? catTitle, CancellationToken cancellationToken);
        Task<ServiceResult> CreateProductAdditive(int categoryId, string title, decimal price, CancellationToken cancellationToken);
        #endregion

        #region ProductPriceOption
        Task<ServiceResult> CreateProductPriceOption(PriceOptionModel model, CancellationToken cancellationToken);
        #endregion

        #region ProductPriceOptionValue
        Task<ServiceResult> CreatePriceOptionValue(PriceOptionValueModel model, CancellationToken cancellationToken);
        #endregion

        #region ProductPrice
        Task<ServiceResult> CreateProductPrice(ProductPriceModel model, CancellationToken cancellationToken);
        #endregion
    }
}
