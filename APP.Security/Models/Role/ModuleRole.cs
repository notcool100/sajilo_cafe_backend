using App.Shared.Models;
using APP.Security.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Models.Users
{
    public class ModuleRole:BaseM
    {
        public string Description { get; set; }
        public List<SubModuleFunction> SubModuleFunctions { get; set; }

    }
}
