using System.Collections.Generic;
using System.Linq;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.Mapping;
using FitnessGuru.Services.Models.Store;

namespace FitnessGuru.Services.DataServices.Store
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IRepository<ProductCategory> categoriesRepository;

        public ProductCategoriesService(IRepository<ProductCategory> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<ProductCategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .To<ProductCategoryIdAndNameViewModel>().ToList();

            return categories;
        }

        public bool IsProductCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
