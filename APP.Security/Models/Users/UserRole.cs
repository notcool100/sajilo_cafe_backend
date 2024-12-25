using App.Shared.Models;
using APP.Security.Models.Menu;

namespace APP.Security.Models.Users;

public partial class UserRole : BaseM
{

    public  User User { get; set; } = null!;
    public  List<ModuleRole> ModuleRoles { get; set; } = null!;
    public List<SubModuleFunction> AddtionalSubModuleFunctions { get; set; }
}
