using System.Diagnostics;
using System.Linq;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using Microsoft.AspNetCore.Mvc;
using FitnessGuru.Web.Models;

namespace FitnessGuru.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Article> articleRepository;

        public HomeController(IRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var articles = this.articleRepository.All().Select(x => new ArticleViewModel
            {
                Content = x.Content,
                CategoryName = x.Category.Name
            });

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
