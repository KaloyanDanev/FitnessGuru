using System.Diagnostics;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.DataServices.Articles;
using FitnessGuru.Services.DataServices.Store;
using FitnessGuru.Services.Models;
using FitnessGuru.Services.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGuru.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly IStoreService storeService;

        public HomeController(IArticlesService articlesService, IStoreService storeService)
        {
            this.articlesService = articlesService;
            this.storeService = storeService;
        }

        public IActionResult Index()
        {
            var articles = this.articlesService.GetArticles(6);
            var products = this.storeService.GetProducts(6);

            var viewModel = new IndexViewModel
            {
                Articles = articles,
                Products = products
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
