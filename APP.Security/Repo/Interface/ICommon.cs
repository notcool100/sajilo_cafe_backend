using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Repo.Interface
{
    internal interface ISecurityCommon
    {
        public string HashPassword(string password);
    }
}
