using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    
    public class BlogService
    {
        private readonly BlogRepository _blogRepository;

        public BlogService(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public List<Blog> getListBlog()
        {
            return _blogRepository.GetAll().ToList();
        }

        public Blog GetBlog(int id)
        {
            return _blogRepository.GetById(id);
        }

        public bool DeleteBlog(int id)
        {
            var blog = _blogRepository.GetById(id);
            if (blog != null)
            {
                _blogRepository.Delete(blog);
                return true;
            }
            return false;
        }
    }
}
