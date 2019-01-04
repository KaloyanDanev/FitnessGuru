using System.Collections.Generic;
using FitnessGuru.Services.Models.Categories;

namespace FitnessGuru.Services.DataServices.Articles
{
   public interface ICategoriesService
   {
       IEnumerable<CategoryIdAndNameViewModel> GetAll();

       bool IsCategoryIdValid(int categoryId);
   }
}
