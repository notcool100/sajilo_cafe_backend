using Security.Infrastructure.Domain;

namespace Security.Infrastructure.Domain.Users;

public partial class User : BaseM
{

    public string Password { get; set; } = null!;
    public string? MAC { get; set; }

    public string? IP { get; set; }

    public string? Email { get; set; }

    public bool? IsLoggedIn { get; set; }

    public DateTime? LastLoggedIn { get; set; }

    public DateTime? LogInExpireTime { get; set; }

    public UserStatus UserStatus { get; set; }
    public RecordStatus Status { get; set; }


    public virtual ICollection<UserStatusLog> StatusHistory { get; set; } = new List<UserStatusLog>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public User()
    {
    }
    public User(string Name, string email, string password, string phoneNo, string entryBy, UserStatus userStatus = UserStatus.Active, RecordStatus status = RecordStatus.Submit)
        : base(entryBy, status)
    {
        Email = email;
        Password = password;
        Status = status;
        UserStatus = userStatus;
    }
    public User(string Name, string email, string password, string phoneNo, User entryUser, UserStatus userStatus = UserStatus.Active, RecordStatus status = RecordStatus.Submit)
       : base(entryUser.Id.ToString(), status)
    {
        Email = email;
        Password = password;
        Status = status;
        UserStatus = userStatus;
    }
}

