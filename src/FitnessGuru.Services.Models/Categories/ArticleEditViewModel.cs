using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Categories
{
   public class ArticleEditViewModel :IMapFrom<Article>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
