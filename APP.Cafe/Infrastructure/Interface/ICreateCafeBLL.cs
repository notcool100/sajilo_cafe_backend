using APP.COMMON;
namespace APP.Cafe.Infrastructure
{
    public interface ICreateCafeBLL
    {
        public JsonResponse Create_Cafe(Models.CreateCafeDTO createCafe);

    }
}
