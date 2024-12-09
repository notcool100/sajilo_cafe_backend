using System;
using System.Collections.Generic;

namespace APP.Security.Models;

public partial class ClkStatus
{
    public int StatusId { get; set; }

    public string? StatusDesc { get; set; }

    public int? IsActive { get; set; }

    public bool? IsVerif { get; set; }

    public string? VerifDesc { get; set; }

    public virtual SecFunction? SecFunction { get; set; }
}
