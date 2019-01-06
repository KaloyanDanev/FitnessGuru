using System.ComponentModel.DataAnnotations;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Content?.Length > 150)
                {
                    return this.Content.Substring(0, 130) + "...";
                }
                else
                {
                    return this.Content;
                }
            }
        }

        public string HtmlContent => this.ShortContent.Replace("\n", "<br />\n");

        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }
    }
}
