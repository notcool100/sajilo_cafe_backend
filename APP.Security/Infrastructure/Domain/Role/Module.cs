namespace Security.App.Infrastructure.Domain.Role;

public partial class Module : BaseM
{


    public int Order { get; set; }
    List<SubModule> SubModules { get; set; }
    public Module(int order, List<SubModule> subModules, User entryBy)
        : base(entryBy.Id.ToString())
    {
        Order = order;
        SubModules = subModules;
    }

}


public partial class SubModule : BaseM
{
    public int Order { get; set; }
    public Menu Menu { get; set; }
    public List<Functions> Functions { get; set; }
    public SubModule(int order, Menu menu, List<Functions> functions, User entryBy)
        : base(entryBy.Id.ToString())
    {
        Order = order;
        Menu = menu;
        Functions = functions;
    }
}

