namespace Cafe.Infrastructure.Application.Interface
{
    public interface ICafe : IBaseInterface<CafeM, CafeContext>
    {
        Task<JsonResponse> Add(CafeInDTO Cafe);
    }
}
