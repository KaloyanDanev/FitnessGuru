using System.ComponentModel.DataAnnotations;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ArticleDescription { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public string ImgUrl { get; set; }
    }
}
