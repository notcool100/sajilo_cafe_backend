using App.Security.Repo.Implementation;
using App.Shared.Models;
using APP.Cafe.Data;
using APP.Cafe.Infrastructure;
using APP.Cafe.Infrastructure.BLL;
using APP.Cafe.Models;
using System.Web.Mvc;

namespace APP.Cafe
{
    public class CreateCafe: Controller
    {
        private readonly ICreateCafeBLL _CreateCafe;
        private readonly Token _token;
        public CreateCafe(ICreateCafeBLL createCafeBll, Token token)
        {
            _CreateCafe = createCafeBll;
            _token = token;
        }
        [HttpPost]
        [Route("CreateCafe")]
        public JsonResponse CreateCafee(CreateCafeDTO CreateCafe)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _CreateCafe.Create_Cafe_Bll(CreateCafe);
                if (response.IsSuccess && response.ResponseData != null)
                {
                    dynamic responsedata = response.ResponseData;

                    if (responsedata.userId != null && responsedata.Username != null)
                    {
                        var jwtToken = _token.GenerateJwtToken(responsedata.userId, responsedata.Username, responsedata.CafeId);
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



