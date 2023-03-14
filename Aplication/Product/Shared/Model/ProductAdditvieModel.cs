using System.ComponentModel.DataAnnotations;

namespace Appliction.Product.Shared.Model.ProductAdditive
{
    public class ProductAdditvieModel
    {
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }  

    }
}
