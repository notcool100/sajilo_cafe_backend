using Security.App.Infrastructure.Domain.Role;

namespace Security.App.Infrastructure.Domain.Users;

public partial class UserRole : BaseM
{

    public User User { get; set; } = null!;
    public List<ModuleRole> ModuleRoles { get; set; } = null!;
    public List<SubModuleFunction> SubModuleFunctions { get; set; }
    public UserRole(User user, List<ModuleRole> moduleRoles, List<SubModuleFunction> subModuleFunctions, User entryBy)
        : base(entryBy.Id.ToString())
    {
        User = user;
        ModuleRoles = moduleRoles;
        SubModuleFunctions = subModuleFunctions;
    }
}
