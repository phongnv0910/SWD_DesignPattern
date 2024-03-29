﻿using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class ProductInfo
    {
        public ProductInfo()
        {
            Images = new HashSet<Image>();
            ImportBillDetails = new HashSet<ImportBillDetail>();
            Discounts = new HashSet<DiscountPr>();
            Styles = new HashSet<Style>();
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? MainImage { get; set; }
        public int? ProductId { get; set; }

        public string? Price { get; set; }

        public virtual Product? Product { get; set; }

        public virtual ICollection<Blog>? Blogs { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }

        public virtual ICollection<DiscountPr> Discounts { get; set; }
        public virtual ICollection<Style> Styles { get; set; }
    }
}
