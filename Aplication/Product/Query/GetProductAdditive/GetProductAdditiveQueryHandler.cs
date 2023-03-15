using BusinessLayout.Configuration.Queries;
using Services;
using Services.Product;
using Services.Product.Shared.ProductAdditive.Vm;

namespace Application.Product.Query.GetProductAdditive
{
    public class GetProductAdditiveQueryHandler : IQueryHandler<GetProductAdditiveQuery, ServiceResult<List<ProductAddivesVm>>>
    {
        public readonly IProductService _productService;
        public GetProductAdditiveQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult<List<ProductAddivesVm>>> Handle(GetProductAdditiveQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductAdditive(request.Title, request.CategoryTitle, cancellationToken);
            return result;
        }
    }
}
