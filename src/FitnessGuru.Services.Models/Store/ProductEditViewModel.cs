using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Store
{
    public class ProductEditViewModel : IMapFrom<Product>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public string ProductCategoryName { get; set; }
    }
}
