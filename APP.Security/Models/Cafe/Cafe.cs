using System;
using System.Collections.Generic;
using APP.Security.Models.Staff;
using APP.Security.Models.Users;

namespace APP.Security.Models.Cafe;

public partial class CafeM
{
    public int Cafeid { get; set; }

    public string Cafename { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? Subscriptionid { get; set; }

    public DateTime? Createdat { get; set; }

    public byte[]? CafeLogo { get; set; }

    public virtual ICollection<Cafestaff> Cafestaffs { get; set; } = new List<Cafestaff>();

    public virtual ICollection<SecUser> SecUsers { get; set; } = new List<SecUser>();

    public virtual Subscription1? Subscription { get; set; }
}
