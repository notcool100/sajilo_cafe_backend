
using Security.App.Infrastructure.Domain.Users;

namespace Cafe.Infrastructure.Domain.Modals.Cafe;
public class CafeM : BaseM
{
    public string Name { get; set; }
    public string Address { get; set; }

    public int? Subscriptionid { get; set; }

    public byte[]? CafeLogo { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<User> Users { get; set; } = new List<User>();

    public Subscription Subscription { get; set; }

    public CafeM(string Name, string address, int? subscriptionid, byte[]? cafeLogo, User entryBy, RecordStatus status = RecordStatus.Submit)
        : base(entryBy.Id.ToString(), status)
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
