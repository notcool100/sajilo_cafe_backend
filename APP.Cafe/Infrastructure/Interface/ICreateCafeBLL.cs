using App.Shared.Infrastructure;
using App.Shared.Models;
using APP.Cafe.Models;
namespace APP.Cafe.Infrastructure
{
    public interface ICreateCafeBLL : IBaseInterface<CafeM>
    {
         JsonResponse Add(CreateCafeDTO createCafe);
    }
}
