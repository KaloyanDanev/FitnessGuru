using System.ComponentModel.DataAnnotations;

namespace FitnessGuru.Web.Model.Article
{
    public class CreateArticleInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(150)]
        public string Content { get; set; }

        public string ImgUrl { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }
    }
}
