
namespace Cafe.Infrastructure.Domain.Modals.Employees;

public partial class Employee : User
{

    public virtual CafeM Cafe { get; set; } = null!;
    private Employee():base()
    {
    }
    public Employee(string Name, string email, string password, string phoneNo, CafeM cafe, string entryBy, UserStatus status = UserStatus.Active)
       : base(Name, email, password, phoneNo, entryBy, status)
    {
        Cafe = cafe;
    }

}
