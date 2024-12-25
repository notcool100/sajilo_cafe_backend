using App.Shared.Models;

namespace APP.Security.Models.Users;

public partial class UserStatusLog:BaseM
{
    public int UserId { get; set; }

    public string UserStatus { get; set; } = null!;

    public string FromDate { get; set; } = null!;

    public short SeqNo { get; set; }

    public string? ToDate { get; set; }

    public string? EntryBy { get; set; }

    public DateOnly? EntryDate { get; set; }

    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public virtual SecUser User { get; set; } = null!;
}
