using BusinessLayout.Configuration.Queries;
using Services;
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
}
