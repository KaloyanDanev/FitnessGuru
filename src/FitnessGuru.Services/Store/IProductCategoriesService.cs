using System.Collections.Generic;
using FitnessGuru.Services.Models.Store;

namespace FitnessGuru.Services.DataServices.Store
{
    public interface IProductCategoriesService
    {
        IEnumerable<ProductCategoryIdAndNameViewModel> GetAll();

        bool IsProductCategoryIdValid(int categoryId);
    }
}
