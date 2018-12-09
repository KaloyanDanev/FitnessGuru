using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
