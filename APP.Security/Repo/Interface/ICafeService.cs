using APP.COMMON;
using APP.Security.Models.Cafe;
using APP.Security.Repo.Data;
using GenericRepositoryEntityFramework;

namespace APP.Security.Repo.Interface
{
    public interface ICafeService : IBaseInterface<CafeM>
    {
        JsonResponse Add(CreateCafeDTO createCafeDTO);
    }
}
