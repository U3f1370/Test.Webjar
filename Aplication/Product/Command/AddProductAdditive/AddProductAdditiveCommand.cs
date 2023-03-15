using Appliction.Product.Shared.Model.ProductAdditive;
using BusinessLayout.Configuration.Commands;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;
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
}
