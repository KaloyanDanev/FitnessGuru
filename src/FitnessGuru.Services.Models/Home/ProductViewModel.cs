using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Content?.Length > 150)
                {
                    return this.Content.Substring(0, 150) + "...";
                }
                else
                {
                    return this.Content;
                }
            }
        }

        public string HtmlContent => this.ShortContent.Replace("\n", "<br />\n");

        public string ProductCategoryName { get; set; }
    }
}
