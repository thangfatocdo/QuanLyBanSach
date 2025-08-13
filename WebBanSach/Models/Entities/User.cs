using System;
using System.Collections.Generic;

namespace WebBanSach.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Role { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<InventoryExport> InventoryExports { get; set; } = new List<InventoryExport>();

    public virtual ICollection<InventoryImport> InventoryImports { get; set; } = new List<InventoryImport>();
}
