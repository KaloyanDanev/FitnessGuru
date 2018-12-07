using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessGuru.Services.Models.Categories;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices
{
    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles(int count);

        int GetCount();

        Task<int> Create(int categoryId,string content);

        ArticleDetailsViewModel GetArticleById(int id);
    }
}
