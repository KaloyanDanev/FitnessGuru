using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices.Articles
{
    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;
        private readonly IRepository<Category> categoriesRespository;

        public ArticlesService(
            IRepository<Article> articlesRepository,
            IRepository<Category> categoriesRespository)
        {
            this.articlesRepository = articlesRepository;
            this.categoriesRespository = categoriesRespository;
        }

        public IEnumerable<ArticleViewModel> GetArticles(int count)
        {
            var articles = this.articlesRepository.All()
                .OrderByDescending(x => x.Id)
                .To<ArticleViewModel>().Take(count).ToList();

            return articles;
        }

        public int GetCount()
        {
            return this.articlesRepository.All().Count();
        }

        public async Task<int> Create(string title,string description, string content, string imgUrl, int categoryId)
        {
            var article = new Article
            {
                Title = title,
                ArticleDescription = description,
                Content = content,
                ImgUrl = imgUrl,
                CategoryId = categoryId,

            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();

            return article.Id;
        }

        public TViewModel GetArticleById<TViewModel>(int id)
        {
            var article = this.articlesRepository.All().Where(x => x.Id == id)
                .To<TViewModel>()
                .FirstOrDefault();

            return article;
        }

        public IEnumerable<ArticleViewModel> GetAllByCategory(int categoryId)
            => this.articlesRepository
                .All()
                .Where(j => j.CategoryId == categoryId)
                .To<ArticleViewModel>();

       
    }
}
