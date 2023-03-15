using Services.Product.Shared.Product;
using Services.Product.Shared.ProductAdditive.Vm;
using Services.Product.Shared.ProductCategory;

namespace Services.Product
{
    public interface IProductService
    {
        #region Product
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
    }
}
