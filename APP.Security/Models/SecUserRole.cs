using System;
using System.Collections.Generic;

namespace APP.Security.Models;

public partial class SecUserRole
{
    public string ApplicationId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string FromDate { get; set; } = null!;

    public string? ToDate { get; set; }

    public string? TranDate { get; set; }

    public string? EntryBy { get; set; }

    public string? AuthNo { get; set; }

    public string? AuthBy { get; set; }

    public string? AuthDate { get; set; }

    public int? RoleSeq { get; set; }

    public virtual SecApplication Application { get; set; } = null!;

    public virtual SecRole SecRole { get; set; } = null!;

    public virtual SecUser User { get; set; } = null!;
}
