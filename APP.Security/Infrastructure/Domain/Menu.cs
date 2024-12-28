namespace Security.App.Infrastructure.Domain;

public partial class Menu : BaseM
{

    public string Name { get; set; }

    public string? ToolTip { get; set; }

    public double? OrderNo { get; set; }

    public string? MUrl { get; set; }

    public Guid? Parent { get; set; }

    public string? HasChild { get; set; }

    public string? MenuIcon { get; set; }
    public Menu(string name, string toolTip, double orderNo, string mUrl, Guid parent, string hasChild, string menuIcon, User entryBy)
        : base(entryBy.Id.ToString())
    {
        Name = name;
        ToolTip = toolTip;
        OrderNo = orderNo;
        MUrl = mUrl;
        Parent = parent;
        HasChild = hasChild;
        MenuIcon = menuIcon;
    }
}
