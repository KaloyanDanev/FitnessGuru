using System.ComponentModel.DataAnnotations;

namespace FitnessGuru.Web.Model.Article
{
    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(150)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
