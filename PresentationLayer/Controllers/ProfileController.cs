using BusinessLayer.Service;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly UserBus _userService;
        public ProfileController(ILogger<ProfileController> logger, UserBus userService)
        {
            _logger = logger;
            _userService = userService;

        }
        public IActionResult UpdateProfile(int id)
        {
            User user = _userService.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            await _userService.Update(user);
            return RedirectToAction(nameof(UpdateProfile), new { id = user.Id });
        }
    }
}
