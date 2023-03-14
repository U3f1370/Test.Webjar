using Appliction.Product.Shared.Model.ProductAdditive;
using BusinessLayout.Configuration.Commands;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;
using Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Command.AddProductAdditive
{
    public class AddProductAdditiveCommand:CommandBase<ServiceResult>
    {
        public ProductAdditvieModel Model { get; set; }

        public AddProductAdditiveCommand(ProductAdditvieModel model)
        {
            Model = model;
        }
    }

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
