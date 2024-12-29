using Security.Infrastructure.Domain;
using Security.Infrastructure.Domain.Users;

namespace Security.Infrastructure.Domain.Role;

public partial class Module : BaseM
{


    public int Order { get; set; }
    List<SubModule> SubModules { get; set; }
    private Module()
    {
    }
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
    private SubModule()
    {
    }
    public SubModule(int order, Menu menu, List<Functions> functions, User entryBy)
        : base(entryBy.Id.ToString())
    {
        Order = order;
        Menu = menu;
        Functions = functions;
    }
}

