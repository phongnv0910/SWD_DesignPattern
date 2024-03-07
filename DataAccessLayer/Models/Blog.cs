using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public partial class Blog
    {
        public Blog()
        {
           ProductInfos = new HashSet<ProductInfo>();

        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Images { get; set; } = null!;

        public virtual ICollection<ProductInfo>? ProductInfos { get; set; }

    }
}
