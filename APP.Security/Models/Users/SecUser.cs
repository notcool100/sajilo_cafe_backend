using APP.Security.Models.Cafe;

namespace APP.Security.Models.Users;

public partial class SecUser
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? Status { get; set; }

    public decimal? Totalcredit { get; set; }

    public string? TranDate { get; set; }

    public string? Machine { get; set; }

    public string? IpAddress { get; set; }

    public string? Remarks { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Cafeid { get; set; }

    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public string? Email { get; set; }

    public bool? IsLoggedIn { get; set; }

    public DateTime? LastLoggedIn { get; set; }

    public DateTime? LogInExpireTime { get; set; }

    public virtual CafeM? Cafe { get; set; }

    public virtual ICollection<SecUsersStatus> SecUsersStatuses { get; set; } = new List<SecUsersStatus>();
}
