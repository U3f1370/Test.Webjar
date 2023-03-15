using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product.Shared.ProductPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Command.AddProductPrice
{
    public class AddProductPriceCommand : CommandBase<ServiceResult>
    {
        public ProductPriceModel Model { get; set; }

        public AddProductPriceCommand(ProductPriceModel model)
        {
            Model = model;
        }
    }
}
