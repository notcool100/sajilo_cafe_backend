using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using APP.COMMON;
using APP.Security;
using APP.Security.Repo.Implimantation;
using APP.Security.Models.Users;

namespace sajilo_cafe_backend.Controllers.security
{
    public class LoginController : Controller
    {
        private readonly ILoginUser _loginUser;
        private readonly Token _token;

        [HttpPost]
        [Route("login")]
        public async Task<JsonResponse> login(SecUser user)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = await _loginUser.Login(user);
                if (response.IsSuccess)
                {
                    dynamic responsedata = response.ResponseData;
                    var jwtToken = _token.GenerateJwtToken(responsedata.user_id, responsedata.Username);
                    response.Token = jwtToken;
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
