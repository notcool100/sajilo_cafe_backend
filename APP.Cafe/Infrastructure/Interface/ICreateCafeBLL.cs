using App.Shared.Models;
using APP.Cafe.Models;
namespace APP.Cafe.Infrastructure
{
    public interface ICreateCafeBLL
    {
        public JsonResponse Create_Cafe_Bll(CreateCafeDTO createCafe);
    }
}
