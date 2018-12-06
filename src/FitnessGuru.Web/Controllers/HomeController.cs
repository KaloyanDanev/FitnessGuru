using System.Diagnostics;
using System.Linq;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.Models.Home;
using Microsoft.AspNetCore.Mvc;
using FitnessGuru.Web.Models;

namespace FitnessGuru.Web.Controllers
{
    public class HomeController : Controller
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
