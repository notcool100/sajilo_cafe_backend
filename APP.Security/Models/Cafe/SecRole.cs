using System;
using System.Collections.Generic;
using APP.Security.Models.Menu;
using APP.Security.Models.Staff;

namespace APP.Security.Models.Cafe;

public partial class SecRole
{
    public string ApplicationId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string? RoleDescription { get; set; }

    public string? DbRole { get; set; }

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual SecApplication Application { get; set; } = null!;

    public virtual ICollection<SecStaffRole> SecStaffRoles { get; set; } = new List<SecStaffRole>();
}
