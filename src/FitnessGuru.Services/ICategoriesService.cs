using System.Collections.Generic;
using System.Text;
using FitnessGuru.Services.Models;

namespace FitnessGuru.Services.DataServices
{
   public interface ICategoriesService
   {
       IEnumerable<IdAndNameViewModel> GetAll();

       bool IsCategoryIdValid(int categoryId);
   }
}
