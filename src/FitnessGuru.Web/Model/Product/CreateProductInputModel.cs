using System.ComponentModel.DataAnnotations;

namespace FitnessGuru.Web.Model.Product
{
    public class CreateProductInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
