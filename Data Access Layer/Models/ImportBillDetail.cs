using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class ImportBillDetail
    {
        public int Id { get; set; }
        public int ImportBillId { get; set; }
        public int ProductInfoId { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }
        public DateTime ExpiredDate { get; set; }

        public virtual ImportBill ImportBill { get; set; } = null!;
        public virtual ProductInfo ProductInfo { get; set; } = null!;
    }
}
