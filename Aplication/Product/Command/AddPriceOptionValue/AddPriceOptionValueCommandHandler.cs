using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;

namespace Application.Product.Command.AddPriceOptionValue
{
    public class AddPriceOptionValueCommandHandler : ICommandHandler<AddPriceOptionValueCommand, ServiceResult>
    {
        private readonly IProductService _productService;

        public AddPriceOptionValueCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ServiceResult> Handle(AddPriceOptionValueCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.CreatePriceOptionValue(request.Model, cancellationToken);
            return result;
        }
    }
}
