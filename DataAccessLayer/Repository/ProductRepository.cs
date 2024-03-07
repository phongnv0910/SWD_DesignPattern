using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{

    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(SWDContext context) : base(context)
        {
        }

    }

}
