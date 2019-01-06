using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessGuru.Services.Models.Home;

namespace FitnessGuru.Services.DataServices.Store
{
    public interface IStoreService
    {
        IEnumerable<ProductViewModel> GetProducts(int count);

        int GetCount();

        Task<int> Create(int categoryId, string content, string title, decimal price,string imgUrl);

        TViewModel GetProductById<TViewModel>(int id);

        IEnumerable<ProductViewModel> GetAllByCategory(int categoryId);
    }
}
