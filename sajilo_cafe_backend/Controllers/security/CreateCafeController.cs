using APP.Security.Repo.Implimantation;
using APP.Security;
using Microsoft.AspNetCore.Mvc;
using APP.COMMON;
using APP.Security.Repo.Interface;
using APP.Security.Models;

namespace sajilo_cafe_backend.Controllers.security
{
    public class CreateCafeController : Controller
    {
        private readonly ICreateCafe _CreateCafe;
        private readonly Token _token;
        public CreateCafeController(ICreateCafe CreateCafe, Token token)
        {
            _CreateCafe = CreateCafe;
            _token = token;
        }
        [HttpPost]
        [Route("CreateCafe")]
        public JsonResponse CreateCafe(SecUser CreateCafe)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response =  _CreateCafe.Create_Cafe(CreateCafe);
                if (response.IsSuccess && response.ResponseData != null)
                {
                    dynamic responsedata = response.ResponseData;

                    // Ensure required fields are present in ResponseData
                    if (responsedata.userId != null && responsedata.Username != null)
                    {
                        var jwtToken = _token.GenerateJwtToken(responsedata.userId, responsedata.Username);
                        response.Token = jwtToken;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Invalid response data.";
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to create cafe or retrieve response data.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
