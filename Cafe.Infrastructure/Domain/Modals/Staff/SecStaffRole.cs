namespace Cafe.Infrastructure.Domain.Modals.Staff;

public partial class EmployeeRole : BaseM
{
    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public int SeqNo { get; set; }


    public  SecRole SecRole { get; set; } = null!;
    public EmployeeRole(SecRole secRole, int seqNo, string entryBy)
        : base(entryBy)
    {
        SecRole = secRole;
        SeqNo = seqNo;
    }

}
