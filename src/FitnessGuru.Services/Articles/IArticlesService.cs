using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices.Articles
{
    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles(int count);

        int GetCount();

        Task<int> Create(int categoryId,string content, string title, string imgUrl);

        TViewModel GetArticleById<TViewModel>(int id);

        IEnumerable<ArticleViewModel> GetAllByCategory(int categoryId);
    }
}
