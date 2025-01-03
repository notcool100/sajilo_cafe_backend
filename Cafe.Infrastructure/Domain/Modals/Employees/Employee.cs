﻿
namespace Cafe.Infrastructure.Domain.Modals.Employees;

public partial class Employee : BaseM
{
    public string Name { get; set; }

    public virtual CafeM Cafe { get; set; } = null!;
    private Employee():base()
    {
    }
    public Employee(string Name, string email, string password, string phoneNo, CafeM cafe, string entryBy, RecordStatus status = RecordStatus.Submit)
      : base(entryBy, status)
    {
        Cafe = cafe;
    }

}
