using APP.Security.Models.Staff;
using APP.Security.Models.Users;

namespace APP.Cafe.Models;

public class CafeM
{
    public int Cafeid { get; set; }

    public string Cafename { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? Subscriptionid { get; set; }

    public DateTime? Createdat { get; set; }

    public byte[]? CafeLogo { get; set; }

    public  ICollection<Cafestaff> Cafestaffs { get; set; } = new List<Cafestaff>();

    public  ICollection<SecUser> SecUsers { get; set; } = new List<SecUser>();

    public  Subscription? Subscription { get; set; }
}
