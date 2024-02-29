using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class DiscountPr
    {
        public DiscountPr()
        {
            ProductInfos = new HashSet<ProductInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<ProductInfo> ProductInfos { get; set; }
    }
}
