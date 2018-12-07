using System.Diagnostics;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.Models;
using FitnessGuru.Services.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGuru.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IArticlesService articlesService;

        public HomeController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public IActionResult Index()
        {
            var articles = this.articlesService.GetArticles(9);

            var viewModel = new IndexViewModel
            {
                Articles = articles
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
