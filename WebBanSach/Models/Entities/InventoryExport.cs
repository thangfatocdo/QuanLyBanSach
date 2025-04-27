using System;
using System.Collections.Generic;

namespace WebBanSach.Models.Entities;
public partial class InventoryExport
{
    public string IepId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? ExportDate { get; set; }

    public virtual User? User { get; set; }
}
