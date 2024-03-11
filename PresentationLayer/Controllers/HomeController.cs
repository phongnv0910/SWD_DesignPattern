using Business_Layer.Service;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeBus _homeService;
        public HomeController(ILogger<HomeController> logger, HomeBus homeService)
        {
            _logger = logger;
            _homeService = homeService;

        }

        public IActionResult Index()
        {
            var productList = _homeService.GetListProduct();

            return View(productList);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _homeService.DeleteProduct(id);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _homeService.UpdateProduct(product);

            return RedirectToAction("Index", "Home");
        }

    }


}
