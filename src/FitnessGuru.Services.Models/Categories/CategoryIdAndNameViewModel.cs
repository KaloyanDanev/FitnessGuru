using FitnessGuru.Models.Articles;
using FitnessGuru.Services.Mapping;

namespace FitnessGuru.Services.Models.Categories
{
    public class CategoryIdAndNameViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameCount => $"{this.Name} ({this.ArticlesCount})";

        public int ArticlesCount { get; set; }
    }
}
