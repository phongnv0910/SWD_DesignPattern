using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            ReceivingAddresses = new HashSet<ReceivingAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ReceivingAddress> ReceivingAddresses { get; set; }
    }
}
