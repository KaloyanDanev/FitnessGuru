using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Data.Common;
using FitnessGuru.Models.Articles;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.Mapping;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices.Store
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Product> productsRepository;
        private readonly IRepository<ProductCategory> productCategoryRepository;

        public StoreService(
            IRepository<Product> productsRepository,
            IRepository<ProductCategory> productCategoryRepository)
        {
            this.productsRepository = productsRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public IEnumerable<ProductViewModel> GetProducts(int count)
        {
            var products = this.productsRepository.All()
                .OrderByDescending(x => x.Id)
                .To<ProductViewModel>().Take(count).ToList();

            return products;
        }

        public int GetCount()
        {
            return this.productsRepository.All().Count();
        }

        public async Task<int> Create(int categoryId, string content, string title, decimal price)
        {
            var product = new Product
            {
                Title = title,
                ProductCategoryId = categoryId,
                Content = content,
                Price = price
            };
            await this.productsRepository.AddAsync(product);
            await this.productsRepository.SaveChangesAsync();

            return product.Id;
        }

        public TViewModel GetProductById<TViewModel>(int id)
        {
            var product = this.productsRepository.All().Where(x => x.Id == id)
                .To<TViewModel>()
                .FirstOrDefault();

            return product;
        }

        public IEnumerable<ProductViewModel> GetAllByCategory(int categoryId)
            => this.productsRepository.All().Where(x => x.ProductCategoryId == categoryId)
                .To<ProductViewModel>();
    }
}