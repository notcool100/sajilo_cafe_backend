using Cafe.App.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.App.API
{
    [ApiController]
    [Route("[controller]")]
    public class CafeController : Controller
    {
        private readonly ICafe _cafe;
        public CafeController(ICafe cafe)
        {
            _cafe = cafe;
        }
        [HttpGet("Add")]
        public JsonResponse Create(CafeInDTO CreateCafe)
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
