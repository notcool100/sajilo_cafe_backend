namespace Security.Infrastructure.Domain.Users;

public partial class UserStatusLog : BaseM
{

    public string UserStatus { get; set; } = null!;

    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public UserStatusLog()
    {
    }
    public UserStatusLog(string userStatus, User entryBy)
        : base(entryBy.Id.ToString())
    {
        UserStatus = userStatus;
    }
}
