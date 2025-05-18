using System;
using System.Collections.Generic;

namespace AIGoiYSanPham.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public double? BookPrice { get; set; }

    public int? BookQuantity { get; set; }

    public string? CustomerPhone { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Order? Order { get; set; }
}
