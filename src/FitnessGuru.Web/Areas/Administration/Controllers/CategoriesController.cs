using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.DataServices.Articles;
using FitnessGuru.Web.Areas.Administration.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessGuru.Web.Areas.Administration.Controllers
{
    
    public class CategoriesController : AdministrationBaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRepository<Category> categories;

        public CategoriesController(
            ICategoriesService categoriesService, IRepository<Category> categories)
        {
            this.categoriesService = categoriesService;
            this.categories = categories;
        }

        public IActionResult Index()
        {
            var categories = categoriesService
                .GetAll()
                .ToList();

            return this.View(categories);
        }

        public IActionResult Create() => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            var newCategory = Mapper.Map<Category>(model);
            await this.categories.AddAsync(newCategory);
            await this.categories.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) => this.View();

        [HttpPost]
        public IActionResult Edit(EditCategoryInputModel model)
        {
            return null;
        }

        public IActionResult Delete(int id) => this.View();

        [HttpPost]
        public IActionResult Delete(DeleteCategoryInputModel model)
        {
            return null;
        }
    }
}