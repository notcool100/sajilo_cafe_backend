

using System.Configuration;

namespace Cafe.App.Controllers
{

    [Route("api/[controller]")]
    public class CafeController : BaseController<CafeInDTO,CafeOutDTO>
    {
        private readonly ICafe _cafe;
        public CafeController(ICafe cafe) 
        {
            _cafe = cafe;
        }

        public override async Task<JsonResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Get()
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Get(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Patch( CafeInDTO obj)
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Post(CafeInDTO obj)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response =  await _cafe.Add(obj);

            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }

       
    }
}
