using Cafe.Infrastructure.Infrastructure;
using Cafe.Infrastructure.Domain;
using Shared.App;

namespace Cafe.App.Interface
{
    public interface ICafe:IBaseInterface<CafeM>
    {
        JsonResponse Add(CreateCafeDTO Cafe);
    }
}
