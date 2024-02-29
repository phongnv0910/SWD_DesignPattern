using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class ReceivingAddress
    {
        public ReceivingAddress()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Address { get; set; }
        public bool? IsDefault { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
