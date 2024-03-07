using Business_Layer.Service;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
    
        private readonly ILogger<ProductController> _logger;
        private readonly HomeService _homeService;
        public ProductController(ILogger<ProductController> logger, HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;

        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _homeService.DeleteProduct(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await _homeService.UpdateProduct(product);

            return RedirectToAction("Index", "Home");
        }
    }
}
