using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Services.DataServices.Articles;
using FitnessGuru.Services.Models.Categories;
using FitnessGuru.Web.Model.Article;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessGuru.Web.Controllers.Article
{
    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;

        public ArticlesController(IArticlesService articlesService, ICategoriesService categoriesService)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.categoriesService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameCount
            });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            var id = await this.articlesService.Create(input.Title, input.ArticleDescription, input.Content, input.ImgUrl,input.CategoryId);
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var article = this.articlesService.GetArticleById<ArticleDetailsViewModel>(id);
            return this.View(article);
        }     
    }
}
