using System.Linq;
using FitnessGuru.Services.DataServices.Articles;
using FitnessGuru.Services.DataServices.Store;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FitnessGuru.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;
        private readonly IProductCategoriesService productCategoriesService;
        private readonly IStoreService storeService;

        public CategoriesController(
            ICategoriesService categoriesService,
            IArticlesService articlesService,
            IProductCategoriesService productCategoriesService,
            IStoreService storeService)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
            this.productCategoriesService = productCategoriesService;
            this.storeService = storeService;
        }

        public IActionResult ArticlesCategory(int id, int? page)
        {
            var articlesInCategory = this.articlesService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedArticles = articlesInCategory.ToPagedList(nextPage, 100);

            return this.View(pagedArticles);
        }

        public IActionResult ProductsCategory(int id, int? page)
        {
            var productInCategory = this.storeService.GetAllByCategory(id).ToList();
             
            var nextPage = page ?? 1;

            var pagedProduct = productInCategory.ToPagedList(nextPage, 100);

            return this.View(pagedProduct);
        }
    }
}