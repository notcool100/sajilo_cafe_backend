using APP.COMMON;
using APP.Security.Models.Users;
using APP.Security.Repo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security
{
    public interface ILoginUser
    {
          public Task<JsonResponse>Login(LoginDTO login);
    }
}
