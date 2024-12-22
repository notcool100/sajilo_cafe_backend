using APP.Security.Repo.Implimantation;
using APP.Security;
using Microsoft.AspNetCore.Mvc;
using APP.COMMON;
using APP.Security.Repo.Interface;
using APP.Security.Models.Users;
using APP.Security.Models.Cafe;
using APP.Security.Repo.Data;

namespace sajilo_cafe_backend.Controllers.security
{
    public class CreateCafeController : Controller
    {
        private readonly ICafeService _service;
        private readonly Token _token;
        public CreateCafeController(ICafeService cafeservice, Token token)
        {
            _service = cafeservice;
            _token = token;
        }
        [HttpPost]
        [Route("CreateCafe")]
        public JsonResponse CreateCafe(CreateCafeDTO CreateCafe)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response =  _service.Add(CreateCafe);
               
            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }
    }
}
