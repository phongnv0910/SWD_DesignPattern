using Business_Layer.Service;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using BusinessLayer.Service;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;
        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;

        }

        [HttpGet]
        [HttpPost]
        public IActionResult GetUser(int id)
        {
            User user = _userService.GetUser(id);
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult UpdateUser(int id)
        {
            User user = _userService.GetUser(id);
            return View();
        }


    }
}
