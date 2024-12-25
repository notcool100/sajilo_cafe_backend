namespace APP.Security.Models.Menu;

public partial class Menu
{
    public short Id { get; set; }

    public string MenuText { get; set; } = null!;

    public string? ToolTip { get; set; }

    public double? OrderNo { get; set; }

    public string? MUrl { get; set; }

    public short ParentId { get; set; }

    public string? HasChild { get; set; }

    public string? MenuIcon { get; set; }

    public List<SubModule> Module { get; set; }
}
