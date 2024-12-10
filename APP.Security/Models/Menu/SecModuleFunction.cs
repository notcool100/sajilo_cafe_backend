using System;
using System.Collections.Generic;

namespace APP.Security.Models.Menu;

public partial class SecModuleFunction
{
    public string ApplicationId { get; set; } = null!;

    public string ModuleId { get; set; } = null!;

    public string FunCd { get; set; } = null!;

    public string? EntryBy { get; set; }

    public DateTime? EntryDate { get; set; }

    public virtual SecApplication Application { get; set; } = null!;

    public virtual SecFunction FunCdNavigation { get; set; } = null!;

    public virtual SecModule SecModule { get; set; } = null!;
}
