using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Link { get; set; } = null!;
        public int? ProductInfoId { get; set; }

        public virtual ProductInfo? ProductInfo { get; set; }
    }
}
