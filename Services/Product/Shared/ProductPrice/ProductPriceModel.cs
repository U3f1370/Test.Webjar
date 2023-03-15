using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product.Shared.ProductPrice
{
    public class ProductPriceModel
    {
        [Required(ErrorMessage = "Required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Inventory { get; set; }
        public decimal? DiscountPrice { get; set; }
        public DateTime? DiscountPriceExpireAt { get; set;}
        public List<OptionValues>? OptionValues { get; set; }
    }

    public class OptionValues
    {
        public int OptionValueId { get; set; }
    }
}
