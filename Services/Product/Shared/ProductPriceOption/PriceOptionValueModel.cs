using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product.Shared.ProductPriceOption
{
    public class PriceOptionValueModel
    {
        [Required(ErrorMessage = "Required")]
        public int PriceOptionId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Value { get; set; }
    }
}
