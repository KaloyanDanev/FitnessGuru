using System.Collections.Generic;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices
{
    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles(int count);

        int GetCount();
    }
}
