using BusinessLayout.Configuration.Commands;
using Services;
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
}
