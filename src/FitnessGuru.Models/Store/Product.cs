using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Data.Common;

namespace FitnessGuru.Models.Store
{
    public class Product : BaseModel<int>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
