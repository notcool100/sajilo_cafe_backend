using System.Reflection;

namespace Cafe.Infrastructure.Domain.Modals.Cafe;

public partial class SecRole : BaseM
{


    public string? Description { get; set; }

    public string? DbRole { get; set; }


    public List<Module> Modules { get; set; } = null!;
    public SecRole()
    {
    }
    public SecRole(string description, string dbRole, List<Module> modules, string entryBy)
        : base(entryBy)
    {
        Description = description;
        DbRole = dbRole;
        Modules = modules;
    }
}
