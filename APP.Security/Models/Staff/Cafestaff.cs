using APP.Security.Models.Cafe;

namespace APP.Security.Models.Staff;

public partial class Cafestaff
{
    public int Staffid { get; set; }
    public string Name { get; set; }
    public string password { get; set; }
    public string? phoneNo { get; set; }
    public string? email { get; set; }

    public int Cafeid { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual CafeM Cafe { get; set; } = null!;

    public virtual ICollection<SecStaffRole> SecStaffRoles { get; set; } = new List<SecStaffRole>();
}
