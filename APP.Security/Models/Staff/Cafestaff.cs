using APP.Security.Models.Cafe;
using System;
using System.Collections.Generic;

namespace APP.Security.Models.Staff;

public partial class Cafestaff
{
    public int Staffid { get; set; }

    public int Cafeid { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual CafeM Cafe { get; set; } = null!;

    public virtual ICollection<SecStaffRole> SecStaffRoles { get; set; } = new List<SecStaffRole>();
}
