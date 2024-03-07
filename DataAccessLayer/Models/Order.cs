using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ReceivingAddressId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }
        public decimal? TotalMoney { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual ReceivingAddress? ReceivingAddress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
