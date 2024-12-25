using Shared.App;
using Cafe.App.Interface;
using Cafe.Infrastructure.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.App.API
{
        [ApiController]
    [Route("[controller]")]
    public class CafeController : Controller
    {
        private readonly ICafe _cafe;
        public CafeController(ICafe cafe) { 
        _cafe = cafe;
        }
        [HttpGet("Create_Cafe")]
        public JsonResponse CreateCafee(CreateCafeDTO CreateCafe)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _cafe.Add(CreateCafe);

            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }
    }
}
