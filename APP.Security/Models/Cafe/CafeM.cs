using APP.Common.Models;
using APP.Security.Models.Staff;
using APP.Security.Models.Users;
using GenericRepositoryEntityFramework;

namespace APP.Security.Models.Cafe;

public partial class CafeM : BaseM, IAggregateRoot
{

    public string Cafename { get; internal set; } = null!;

    public string Address { get; internal set; } = null!;

    public int? Subscriptionid { get; internal set; }


    public byte[]? CafeLogo { get; internal set; }

    public virtual ICollection<Cafestaff> Cafestaffs { get; set; } = new List<Cafestaff>();

    public virtual ICollection<SecUser> SecUsers { get; set; } = new List<SecUser>();

    public virtual Subscription? Subscription { get; set; }


    public CafeM() { }

    public CafeM(string cafename, string address, string entryBy, int? subscriptionid, byte[]? cafeLogo = null)
        : base(entryBy)
    {
        Cafename=cafename;
        Address=address;
        Subscriptionid=subscriptionid;
        CafeLogo=cafeLogo;
    }
}
