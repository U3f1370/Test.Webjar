using BusinessLayout.Configuration.Queries;
using Services;
using Services.Product.Shared.ProductAdditive.Vm;

namespace Application.Product.Query.GetProductAdditive
{
    public class GetProductAdditiveQuery:IQuery<ServiceResult<List<ProductAddivesVm>>>
    {
        public string? Title { get; set; }
        public string? CategoryTitle { get; set; }
        public GetProductAdditiveQuery(string? title, string? categoryTitle)
        {
            Title = title;
            CategoryTitle = categoryTitle;
        }
    }
}
