using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{

    public class ProductDAO : Repository<Product>
    {
        public ProductDAO(SWDContext context) : base(context)
        {
        }

    }

}
