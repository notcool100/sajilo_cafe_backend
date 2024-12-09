using System;
using System.Collections.Generic;

namespace APP.Security.Models;

public partial class SecMenu
{
    public short MenuId { get; set; }

    public string MenuText { get; set; } = null!;

    public string? ToolTip { get; set; }

    public string UsedIn { get; set; } = null!;

    public double? OrderNo { get; set; }

    public string? MUrl { get; set; }

    public short ParentId { get; set; }

    public string? HasChild { get; set; }

    public string? SecApl { get; set; }

    public string? MenuIcon { get; set; }

    public virtual ICollection<SecModule> SecModules { get; set; } = new List<SecModule>();
}
