using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Data.Common;

namespace FitnessGuru.Models.Store
{
    public class ProductCategory : BaseModel<int>
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
