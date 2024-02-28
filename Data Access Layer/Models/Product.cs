using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductInfos = new HashSet<ProductInfo>();
        }

        public int Id { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductInfo> ProductInfos { get; set; }
    }
}
