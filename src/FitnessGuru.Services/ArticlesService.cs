using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Models.Categories;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices
{
    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;
        private readonly IRepository<Category> categoriesRespository;

        public ArticlesService(
            IRepository<Article> articlesRepository,
            IRepository<Category> categoriesRespository
            )
        {
            this.articlesRepository = articlesRepository;
            this.categoriesRespository = categoriesRespository;
        }

        public IEnumerable<ArticleViewModel> GetArticles(int count)
        {
            var articles = this.articlesRepository.All()
                .Select(x => new ArticleViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).ToList();

            return articles;
        }

        public int GetCount()
        {
            return this.articlesRepository.All().Count();
        }

        public async Task<int> Create(int categoryId, string content)
        {
            var article = new Article
            {
                CategoryId = categoryId,
                Content = content
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();

            return article.Id;
        }

        public ArticleDetailsViewModel GetArticleById(int id)
        {
            var article = this.articlesRepository.All().Where(x => x.Id == id)
                .Select(x => new ArticleDetailsViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).FirstOrDefault();

            return article;
        }
    }
}
