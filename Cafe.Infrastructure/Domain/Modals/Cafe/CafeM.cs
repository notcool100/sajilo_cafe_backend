

namespace Cafe.Infrastructure.Domain;
public class CafeM : BaseM
{

    public string Address { get; set; } = null!;

    public int? Subscriptionid { get; set; }

    public byte[]? CafeLogo { get; set; }

    public  ICollection<Cafestaff> Employees { get; set; } = new List<Cafestaff>();

    public  ICollection<User> Users { get; set; } = new List<User>();

    public  Subscription Subscription { get; set; }

    public CafeM(string Name,string address, int? subscriptionid, byte[]? cafeLogo, User entryBy,Status status)
        :base(Name,entryBy,status)
    {
        Address = address;
        Subscriptionid = subscriptionid;
        CafeLogo = cafeLogo;
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }
}
