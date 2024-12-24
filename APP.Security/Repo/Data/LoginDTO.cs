using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Repo.Data
{
    public class LoginDTO
    {
        public string Phone_no { get; set; }
        public string password { get; set; }
        public bool Remember_me {  get; set; }
    }
}
