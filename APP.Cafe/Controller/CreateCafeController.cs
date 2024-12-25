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
                response = _CreateCafe.Add(CreateCafe);

            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }
    }
}



