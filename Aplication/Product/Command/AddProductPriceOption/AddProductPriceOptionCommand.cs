using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product.Shared.ProductPriceOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Command.AddProductPriceOption
{
    public class AddProductPriceOptionCommand : CommandBase<ServiceResult>
    {
        public PriceOptionModel Model { get; set; }

        public AddProductPriceOptionCommand(PriceOptionModel model)
        {
            Model = model;
        }
    }
}
