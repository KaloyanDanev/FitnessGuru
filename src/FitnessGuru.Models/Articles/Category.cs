using System.Collections.Generic;
using FitnessGuru.Data.Common;

namespace FitnessGuru.Models.Articles
{
    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
