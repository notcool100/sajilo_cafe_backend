namespace Cafe.Infrastructure.Domain;

public partial class Employee: User
{

    public virtual CafeM Cafe { get; set; } = null!;
    public Employee(string Name, string email, string password, string phoneNo, CafeM cafe, User entryBy, UserStatus status)
        : base(Name, email, password, phoneNo, entryBy, status)
    {
        Cafe = cafe;
    }

}
