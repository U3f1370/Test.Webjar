using BusinessLayout.Configuration.Queries;
using Services;
using Services.Product;
using Services.Product.Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Query.GetProduct
{
    public class GetProductQuery : IQuery<ServiceResult<List<ProductVm>>>
    {
        public GetProductQuery(string? productTitle, string? categoryTitle)
        {
            ProductTitle = productTitle;
            CategoryTitle = categoryTitle;
        }

        public string? ProductTitle { get; set; }
        public string? CategoryTitle { get; set;}
    }

    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ServiceResult<List<ProductVm>>>
    {
        private readonly IProductService _productService;

        public GetProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult<List<ProductVm>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProduct(request.ProductTitle, request.CategoryTitle, cancellationToken);
            return result;
        }
    }
}
