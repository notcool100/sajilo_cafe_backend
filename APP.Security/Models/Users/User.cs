using App.Shared.Models;
using APP.Security.Models.Cafe;

namespace APP.Security.Models.Users;

public partial class User:BaseM
{
    
    public string Password { get;  set; } = null!;
    public string? MAC { get; set; }

    public string? IP { get; set; }

    public string? Email { get; set; }

    public bool? IsLoggedIn { get; set; }

    public DateTime? LastLoggedIn { get; set; }

    public DateTime? LogInExpireTime { get; set; }

    public virtual CafeM? Cafe { get; set; }
    public UserStatus UserStatus { get; set; }

    public virtual ICollection<UserStatusLog> StatusHistory { get; set; } = new List<UserStatusLog>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
