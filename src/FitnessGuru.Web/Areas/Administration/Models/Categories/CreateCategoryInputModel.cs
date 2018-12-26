using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Web.Areas.Administration.Models.Categories
{
    public class CreateCategoryInputModel : IMapFrom<Category>
    {
        public string Name { get; set; }
    }
}
