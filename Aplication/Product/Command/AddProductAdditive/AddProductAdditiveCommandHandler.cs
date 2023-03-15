using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;

namespace Application.Product.Command.AddProductAdditive
{
    public class AddProductAdditiveCommandHandler : ICommandHandler<AddProductAdditiveCommand, ServiceResult>
    {
        private readonly IProductService _productService;

        public AddProductAdditiveCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult> Handle(AddProductAdditiveCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateProductAdditive(request.Model.CategoryId,request.Model.Title,request.Model.Price,cancellationToken);
            return result;
        }
    }
}
