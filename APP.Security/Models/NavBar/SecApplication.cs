using System;
using System.Collections.Generic;
using APP.Security.Models.Cafe;
using APP.Security.Models.Staff;

namespace APP.Security.Models.Menu;

public partial class SecApplication
{
    public string ApplicationId { get; set; } = null!;

    public string? ApplicationDescription { get; set; }

    public short? OrderCode { get; set; }

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual ICollection<SecModuleFunction> SecModuleFunctions { get; set; } = new List<SecModuleFunction>();

    public virtual ICollection<SecModule> SecModules { get; set; } = new List<SecModule>();

    public virtual ICollection<SecRole> SecRoles { get; set; } = new List<SecRole>();

    public virtual ICollection<SecStaffRole> SecStaffRoles { get; set; } = new List<SecStaffRole>();
}
