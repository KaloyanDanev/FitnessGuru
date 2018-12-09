using System.Collections.Generic;
using System.Text;
using FitnessGuru.Services.Models;
using FitnessGuru.Services.Models.Categories;

namespace FitnessGuru.Services.DataServices
{
   public interface ICategoriesService
   {
       IEnumerable<CategoryIdAndNameViewModel> GetAll();

       bool IsCategoryIdValid(int categoryId);
   }
}
