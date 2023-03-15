using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static Common.FileManager.FileExtensions;

namespace Services.Product.Shared.Product
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Required")] 
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [AllowedExtensionsV(ErrorMessage = "فرمت های قابل قبول jpg,png,jpeg,gif,mp4")]
        public IFormFile Image { get; set; }
    }
}
