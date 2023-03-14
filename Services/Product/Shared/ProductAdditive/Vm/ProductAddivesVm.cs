using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product.Shared.ProductAdditive.Vm
{
    public class ProductAddivesVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime CreateDm { get; set; }
        public DateTime? LateUpdateDm { get; set; }
    }
}
