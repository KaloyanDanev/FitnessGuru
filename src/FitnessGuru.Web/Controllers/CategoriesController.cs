using System.Linq;
using FitnessGuru.Services.DataServices.Articles;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FitnessGuru.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IArticlesService articlesService)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
        }

        public IActionResult Details(int id, int? page)
        {
            var articlesInCategory = this.articlesService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedArticles = articlesInCategory.ToPagedList(nextPage, 4);

            return this.View(pagedArticles);
        }
    }
}