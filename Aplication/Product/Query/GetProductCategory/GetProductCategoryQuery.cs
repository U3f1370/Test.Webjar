using BusinessLayout.Configuration.Queries;
using Services;
using Services.Product;
using Services.Product.Shared.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Query.GetProductCategory
{
    public class GetProductCategoryQuery : IQuery<ServiceResult<List<ProductCategoryVm>>>
    {
        public string? Filter { get; set; }

        public GetProductCategoryQuery(string? filter)
        {
            Filter = filter;
        }
    }

    public class GetProductCategoryQueryHandler : IQueryHandler<GetProductCategoryQuery, ServiceResult<List<ProductCategoryVm>>>
    {
        private readonly IProductService _productService;

        public GetProductCategoryQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult<List<ProductCategoryVm>>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductCategory(request.Filter, cancellationToken);
            return result;
        }
    }
}
