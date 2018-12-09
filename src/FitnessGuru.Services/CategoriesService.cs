using System;
using System.Collections.Generic;
using System.Linq;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;
using FitnessGuru.Services.Models;
using FitnessGuru.Services.Models.Categories;

namespace FitnessGuru.Services.DataServices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .To<CategoryIdAndNameViewModel>().ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }
    }
}