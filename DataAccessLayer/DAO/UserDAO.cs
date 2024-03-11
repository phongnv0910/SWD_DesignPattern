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
   

    public class UserDAO : Repository<User>
    {
        public UserDAO(SWDContext context) : base(context)
        {
        }
      
    }
}
