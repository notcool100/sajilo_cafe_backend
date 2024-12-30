



namespace Cafe.Infrastructure.Domain.Modals.Cafe;
public class CafeM : BaseM
{
    public string Name { get; set; }
    public string Address { get; set; }

    public int? Subscriptionid { get; set; }

    public byte[]? CafeLogo { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();


    public Subscription Subscription { get; set; }

    private CafeM()
    {
    }
    public CafeM(string Name, string address, int? subscriptionid, byte[]? cafeLogo, string entryBy, RecordStatus status = RecordStatus.Submit)
        : base(entryBy, status)
    {
        Address = address;
        Subscriptionid = subscriptionid;
        CafeLogo = cafeLogo;
    }
    public void AddEmployee(Employee user)
    {
        Employees.Add(user);
    }
}
