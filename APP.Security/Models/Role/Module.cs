
namespace APP.Security.Models.Menu;

public partial class Module : BaseM
{


    public short? OrderCode { get; set; }
    List<SubModule> SubModules { get; set; } = new List<SubModule>();
}


public partial class SubModule
{

    public string? ModuleType { get; set; }


    public string? McRestricted { get; set; }

    public short? MOrderCode { get; set; }

    public string? UsesBy { get; set; }

    public Menu Menu { get; set; }
    public  List<Functions> Functions { get; set; }
    public virtual Module Module { get;}

}

