using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices.Articles
{
    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles(int count);

        int GetCount();

        Task<int> Create(string title, string description, string content, string imgUrl, int categoryId);

        TViewModel GetArticleById<TViewModel>(int id);

        IEnumerable<ArticleViewModel> GetAllByCategory(int categoryId);
    }
}
