using Data_Access_Layer.Repository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
   

    public class UserRepository : Repository<User>
    {
        public UserRepository(SWDContext context) : base(context)
        {
        }
      
    }
}
