using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Services.DataServices;
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

        public IActionResult Index()
        {
            var categories = categoriesService
                .GetAll()
                .ToList();

            return this.View(categories);
        }

        public IActionResult Details(int id, int? page)
        {
            var jokesInCategory = this.articlesService.GetAllByCategory(id).ToList();

            var nextPage = page ?? 1;

            var pagedArticles = jokesInCategory.ToPagedList(nextPage, 4);

            return this.View(pagedArticles);
        }
    }
}