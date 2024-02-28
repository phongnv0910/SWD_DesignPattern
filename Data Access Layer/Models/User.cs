using System;
using System.Collections.Generic;

namespace Data_Access_Layer.Models
{
    public partial class User
    {
        public User()
        {
            ImportBills = new HashSet<ImportBill>();
            PaymentMethods = new HashSet<PaymentMethod>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ImportBill> ImportBills { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
