using APP.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Security.Repo.Interface
{
    public interface ICreateCafe
    {
        public JsonResponse Create_Cafe(ATTCreateCafe createCafe);

    }
}
