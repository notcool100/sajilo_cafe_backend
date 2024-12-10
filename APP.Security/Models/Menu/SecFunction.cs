using System;
using System.Collections.Generic;

namespace APP.Security.Models.Menu;

public partial class SecFunction
{
    public string FunCd { get; set; } = null!;

    public string? FunDesc { get; set; }

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<SecModuleFunction> SecModuleFunctions { get; set; } = new List<SecModuleFunction>();

    public virtual ClkStatus Status { get; set; } = null!;
}
