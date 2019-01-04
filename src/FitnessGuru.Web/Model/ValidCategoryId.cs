using System.ComponentModel.DataAnnotations;
using FitnessGuru.Services.DataServices;
using FitnessGuru.Services.DataServices.Articles;

namespace FitnessGuru.Web.Model
{
    public class ValidCategoryId : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (ICategoriesService) validationContext
                .GetService(typeof(ICategoriesService));

            if (service.IsCategoryIdValid((int)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid category id!");
            }
        }
    }
}