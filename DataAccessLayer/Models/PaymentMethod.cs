using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
