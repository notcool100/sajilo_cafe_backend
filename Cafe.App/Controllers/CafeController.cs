
namespace Cafe.App.Controllers
{
    public class CafeController : BaseController
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
