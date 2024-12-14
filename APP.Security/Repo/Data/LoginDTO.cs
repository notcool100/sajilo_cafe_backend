using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Repo.Data
{
    public class LoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool remember_me {  get; set; }
    }
}
