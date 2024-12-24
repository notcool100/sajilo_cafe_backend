using APP.COMMON;
using APP.Security.Repo.Data;
using APP.Security.Repo.Implimantation;
using APP.Security.Repo.Interface;
using Microsoft.AspNetCore.Mvc;

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
