
using Security.App.Infrastructure.Domain;
using Security.App.Infrastructure.Domain.Users;

namespace Cafe.Infrastructure.Domain.Modals.Staff;

public partial class Employee : User
{

    public virtual CafeM Cafe { get; set; } = null!;

    public Employee(string Name, string email, string password, string phoneNo, CafeM cafe, string entryBy, UserStatus status = UserStatus.Active)
       : base(Name, email, password, phoneNo, entryBy, status)
    {
        Cafe = cafe;
    }

}
