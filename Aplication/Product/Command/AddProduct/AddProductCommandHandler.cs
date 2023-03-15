using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;

namespace Application.Product.Command.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, ServiceResult>
    {
        private readonly IProductService _productService;
        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateProduct(request.Model,cancellationToken);
            return result;
        }
    }
}
