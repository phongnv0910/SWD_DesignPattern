using Business_Layer.Service;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using BusinessLayer.Service;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly UserBus _userService;
        public UserController(ILogger<UserController> logger, UserBus userService)
        {
            _logger = logger;
            _userService = userService;

        }

		public IActionResult Index()
		{
			var users = _userService.GetListUser();

			return View(users);
		}

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> ViewDetails(int id)
        {
            User user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
             await _userService.Update(user);
            return RedirectToAction("Index", "User");
        }


    }
}
