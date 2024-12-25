using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Models
{
    public enum UserStatus
    {
        Active = 1,
        Inactive = 2,
        Deleted = 5
    }
    public enum Functions
    {
        CreateUpdate = 1,
        View = 2,
        Delete = 3
    }
    
}
