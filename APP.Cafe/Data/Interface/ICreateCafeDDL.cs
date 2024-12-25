using App.Shared.Models;
using APP.Cafe.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Cafe.Data.Interface
{
    internal interface ICreateCafeDDL
    {
        public JsonResponse Create_Cafe_Ddl(CreateCafeDTO createCafe);
    }
}
