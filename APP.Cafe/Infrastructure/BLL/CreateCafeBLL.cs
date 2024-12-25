using APP.Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.Security.Repo.Common;
using APP.Cafe.Data.Interface;
using App.Shared.Models;

namespace APP.Cafe.Infrastructure.BLL
{
    internal class CreateCafeBLL : ICreateCafeBLL
    {
        private readonly ICreateCafeDDL _createCafeDDL;
        public CreateCafeBLL(ICreateCafeDDL createCafeDDL)
        {
            _createCafeDDL = createCafeDDL;
        }

        public JsonResponse Create_Cafe_Bll(CreateCafeDTO createCafe)
        {

            JsonResponse response = new JsonResponse();
                try
                {
                createCafe.Password= PasswordHash.HashedPassword(createCafe.Password);
                response = _createCafeDDL.Create_Cafe(createCafe);
                }
           
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.HasError = true;
                    response.Message = $"An error occurred: {ex.Message}";
                }
            return response;
        }

     
    }
}
