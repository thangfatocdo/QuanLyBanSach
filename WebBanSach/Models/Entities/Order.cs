using System;
using System.Collections.Generic;

namespace WebBanSach.Models.Entities;
public partial class Order
{
    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Payment { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public string? Status { get; set; }

    public double? TotalPrice { get; set; }

    public int OrderId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
