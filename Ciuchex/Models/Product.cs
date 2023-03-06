using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ciuchex.Models
{
    public class Product
    {
        [Display(Name = "Product Id")]
        public long Id { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }

        
        [Display(Name = "Description")]
        [Required, MinLength(4, ErrorMessage = "Minimum length is 2")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "You must choose a category")]
        public long CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; } = "default_photo.png";

    }
}
