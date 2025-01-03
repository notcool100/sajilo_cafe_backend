﻿using Security.Infrastructure.Domain;
using Security.Infrastructure.Domain.Users;

namespace Security.Infrastructure.Domain.Role;

public partial class SubModuleFunction : BaseM
{
    public SubModule SubModule { get; set; }
    public List<Functions> Functions { get; set; }
    public SubModuleFunction()
    {
    }
    public SubModuleFunction(SubModule subModule, List<Functions> functions, User entryBy)
        : base(entryBy.Id.ToString())
    {
        SubModule = subModule;
        Functions = functions;
    }

}
