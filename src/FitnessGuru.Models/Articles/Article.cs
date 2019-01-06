using FitnessGuru.Data.Common;

namespace FitnessGuru.Models.Articles
{
    public class Article : BaseModel<int>
    {
        public string Title { get; set; }

        public string ArticleDescription { get; set; }

        public string Content { get; set; }

        public string ImgUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
