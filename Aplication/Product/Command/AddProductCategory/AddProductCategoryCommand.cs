using BusinessLayout.Configuration.Commands;
using Entities.Product;
using Services;
using Services.Product;

namespace Application.Product.Command.AddProductCategory
{
    public class AddProductCategoryCommand: CommandBase<ServiceResult>
    {
        public string Title { get; set; }
        public AddProductCategoryCommand(string title)
        {
            Title = title;
        }
    }
    public class AddProductCategoryCommandHandler : ICommandHandler<AddProductCategoryCommand, ServiceResult>
    {
        private readonly IProductService _ProductService;

        public AddProductCategoryCommandHandler(IProductService productService)
        {
            _ProductService = productService;
        }

        public async Task<ServiceResult> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _ProductService.CreateCategory(request.Title, cancellationToken);
            return result;
        }
    }
}
