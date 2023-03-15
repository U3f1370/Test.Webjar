using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;

namespace Application.Product.Command.AddProductPrice
{
    public class AddProductPriceCommandHandler : ICommandHandler<AddProductPriceCommand, ServiceResult>
    {
        private readonly IProductService _productService;

        public AddProductPriceCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult> Handle(AddProductPriceCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateProductPrice(request.Model, cancellationToken);
            return result;
        }
    }
}
