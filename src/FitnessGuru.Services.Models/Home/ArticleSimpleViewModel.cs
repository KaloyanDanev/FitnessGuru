using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Home
{
    public class ArticleSimpleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
