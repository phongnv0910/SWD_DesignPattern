using Business_Layer.Service;
using BusinessLayer.Service;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        private readonly BlogService _blogService;

        public BlogController(ILogger<BlogController> logger, BlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewAll()
        {
            List<Blog> blogs = _blogService.getListBlog();
            return View(blogs);
        }

        public IActionResult GetById(int id)
        {
            Blog blog = _blogService.GetBlog(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Delete(int id)
        {
            _blogService.DeleteBlog(id);
            return RedirectToAction("ViewAll"); 
        }
    }
}
