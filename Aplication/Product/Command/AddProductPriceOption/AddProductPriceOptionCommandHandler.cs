using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;

namespace Application.Product.Command.AddProductPriceOption
{
    public class AddProductPriceOptionCommandHandler : ICommandHandler<AddProductPriceOptionCommand, ServiceResult>
    {
        private readonly IProductService _productService;

        public AddProductPriceOptionCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult> Handle(AddProductPriceOptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreateProductPriceOption(request.Model, cancellationToken);
            return result;
        }
    }
}
