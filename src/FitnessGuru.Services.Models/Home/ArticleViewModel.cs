using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string HtmlContent => this.Content.Replace("\n", "<br />\n");

        public string CategoryName { get; set; }
    }
}
