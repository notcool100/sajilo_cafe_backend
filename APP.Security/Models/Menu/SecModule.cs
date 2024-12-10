using System;
using System.Collections.Generic;

namespace APP.Security.Models.Menu;

public partial class SecModule
{
    public string ApplicationId { get; set; } = null!;

    public string ModuleId { get; set; } = null!;

    public string? ModuleDescription { get; set; }

    public string? ModuleType { get; set; }

    public string? MenuName { get; set; }

    public string? McRestricted { get; set; }

    public short? MOrderCode { get; set; }

    public string? UsesBy { get; set; }

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public short? MenuId { get; set; }

    public bool? IsActive { get; set; }

    public virtual SecApplication Application { get; set; } = null!;

    public virtual SecMenu? Menu { get; set; }

    public virtual ICollection<SecModuleFunction> SecModuleFunctions { get; set; } = new List<SecModuleFunction>();
}
