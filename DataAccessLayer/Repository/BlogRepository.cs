using Data_Access_Layer.Repository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
   
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository(SWDContext context) : base(context)
        {
        }

    }
}
