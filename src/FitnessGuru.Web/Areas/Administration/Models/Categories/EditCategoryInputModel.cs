using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Web.Areas.Administration.Models.Categories
{
    public class EditCategoryInputModel : IMapTo<Category>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EditCategoryInputModel, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
