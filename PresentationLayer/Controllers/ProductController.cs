using Business_Layer.Service;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
    
        private readonly ILogger<ProductController> _logger;
        private readonly ProductBus _productService;
        public ProductController(ILogger<ProductController> logger, ProductBus productService)
        {
            _logger = logger;
			_productService = productService;

        }

		public IActionResult Index()
		{
			var productList = _productService.GetListProduct();

			return View(productList);
		}

		[HttpGet]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
		public async Task<IActionResult> Update(Product product)
        {
            await _productService.UpdateProduct(product);

            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
		[HttpGet]
		public async Task<IActionResult> ViewDetails(int id)
        {
            var result =await _productService.GetProductById(id);

            return View(result);
        }
    }
}
