using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class ImportBill
    {
        public ImportBill()
        {
            ImportBillDetails = new HashSet<ImportBillDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal TotalMoney { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<ImportBillDetail> ImportBillDetails { get; set; }
    }
}
