namespace Security.App.Infrastructure.Domain.Users;

public partial class UserStatusLog : BaseM
{
    public int UserId { get; set; }

    public string UserStatus { get; set; } = null!;

    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public User User { get; set; }
    public UserStatusLog(int userId, string userStatus, User entryBy)
        : base(entryBy.Id.ToString())
    {
        UserId = userId;
        UserStatus = userStatus;
    }
}
