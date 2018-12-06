using System.Collections.Generic;
using System.Linq;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices
{
    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articleRepository;

        public ArticlesService(IRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<ArticleViewModel> GetArticles(int count)
        {
            var articles = this.articleRepository.All()
                .Select(x => new ArticleViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).ToList();

            return articles;
        }

        public int GetCount()
        {
            return this.articleRepository.All().Count();
        }
    }
}
