using System.Linq;
using FitnessGuru.Services.DataServices.Store;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FitnessGuru.Web.Controllers.Store
{
    public class ProductCategoriesController : BaseController
    {
        private readonly IProductCategoriesService productCategoriesService;
        private readonly IStoreService storeService;
        
        public ProductCategoriesController(
            IProductCategoriesService productCategoriesService,
            IStoreService storeService)
        {
            this.productCategoriesService = productCategoriesService;
            this.storeService = storeService;
        }

        public IActionResult Details(int id, int? page)
        {
            var productsInCategory = this.storeService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedArticles = productsInCategory.ToPagedList(nextPage, 4);

            return this.View(pagedArticles);
        }
    }
}