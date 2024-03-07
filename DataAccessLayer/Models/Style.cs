using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Style
    {
        public Style()
        {
            Categories = new HashSet<Category>();
            ProductInfos = new HashSet<ProductInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductInfo> ProductInfos { get; set; }
    }
}
