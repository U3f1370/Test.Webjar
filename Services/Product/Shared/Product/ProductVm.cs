using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product.Shared.Product
{
    public class ProductVm
    {
        public string ProductTitle { get; set; }
        public string ProductCategoryTitle { get; set; }
        public List<Prices>? prices { get; set; }
        public List<Additives>? Additives { get; set; }
    }
    public class Prices
    {
        public decimal? Price { get; set; }
        public int? Inventory { get; set; }
        public decimal? DiscountPrice { get; set; }
        public DateTime? DiscountPriceExpireAt { get; set; }
        public List<Features>? Features { get; set; }
    }
    public class Features
    {
        public string? OptionTitle { get; set; }
        public string? OptionValueTitle { get; set;}
    }

    public class Additives
    {
        public string Title { get; set;}
        public decimal Price { get; set; }
    }
}
