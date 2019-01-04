using System.Collections.Generic;

namespace FitnessGuru.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
