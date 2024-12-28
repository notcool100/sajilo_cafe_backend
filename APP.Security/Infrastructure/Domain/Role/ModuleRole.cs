﻿namespace Security.App.Infrastructure.Domain.Role
{
    public class ModuleRole : BaseM
    {
        public string Description { get; set; }
        public List<Module> Modules { get; set; }
        public ModuleRole(string description, List<Module> modules, User entryBy)
            : base(entryBy.Id.ToString())
        {
            Description = description;
            Modules = modules;
        }

    }
}
