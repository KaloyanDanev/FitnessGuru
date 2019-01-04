using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Store
{
    public class ProductCategoryIdAndNameViewModel : IMapFrom<ProductCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameCount => $"{this.Name} ({this.ProductCount})";

        public int ProductCount { get; set; }
    }
}
