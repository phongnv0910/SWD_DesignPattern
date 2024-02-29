using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Link { get; set; } = null!;
        public int? ProductInfoId { get; set; }

        public virtual ProductInfo? ProductInfo { get; set; }
    }
}
