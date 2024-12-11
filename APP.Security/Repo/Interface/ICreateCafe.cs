using APP.COMMON;
using APP.Security.Models.Cafe;
using APP.Security.Models.Users;
using APP.Security.Repo.Data;
using APP.Security.Repo.Implimantation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Repo.Interface
{
    public interface ICreateCafe
    {
        public JsonResponse Create_Cafe(CreateCafeDTO createCafe);

    }
}
