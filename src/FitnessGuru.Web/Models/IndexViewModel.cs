using System.Collections.Generic;

namespace FitnessGuru.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
