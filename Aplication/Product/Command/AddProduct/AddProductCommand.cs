using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product;
using Services.Product.Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Command.AddProduct
{
    public class AddProductCommand : CommandBase<ServiceResult>
    {
        public ProductModel Model { get; set; }

        public AddProductCommand(ProductModel model)
        {
            Model = model;
        }
    }

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
