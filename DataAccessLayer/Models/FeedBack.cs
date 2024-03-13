using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public partial class FeedBack
    {
        public int Id { get; set; }

        public string _feedBack { get;set; } = null!;

        public string rate { get; set; } = null!;



    }
}
