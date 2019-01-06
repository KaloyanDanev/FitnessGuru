using System.Linq;
using System.Threading.Tasks;
using FitnessGuru.Services.DataServices.Store;
using FitnessGuru.Services.Models.Store;
using FitnessGuru.Web.Model.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessGuru.Web.Controllers.Store
{
    public class ProductsController : BaseController
    {
        private readonly IStoreService storeService;
        private readonly IProductCategoriesService productCategoriesService;

        public ProductsController(IStoreService storeService, IProductCategoriesService productCategoriesService)
        {
            this.storeService = storeService;
            this.productCategoriesService = productCategoriesService;
        }

        [Authorize]
        public IActionResult Create()
        {
            this.ViewData["Categories"] = this.productCategoriesService.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.NameCount
            });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            var id = await this.storeService.Create(input.CategoryId, input.Content, input.Title,input.Price,input.ImgUrl);
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            var product = this.storeService.GetProductById<ProductDetailsViewModel>(id);
            return this.View(product);
        }
    }
}
