using BusinessLayout.Configuration.Commands;
using Services;
using Services.Product.Shared.ProductPriceOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Command.AddPriceOptionValue
{
    public class AddPriceOptionValueCommand : CommandBase<ServiceResult>
    {
        public PriceOptionValueModel Model { get; set; }

        public AddPriceOptionValueCommand(PriceOptionValueModel model)
        {
            Model = model;
        }
    }
}
