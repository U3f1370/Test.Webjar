using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product.Shared.ProductPriceOption
{
    public class PriceOptionModel
    {
        [Required(ErrorMessage ="required")]
        public int CatId { get; set; }
        [Required(ErrorMessage = "required")]
        public string Name { get; set;}
    }
}
