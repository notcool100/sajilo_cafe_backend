namespace Cafe.Infrastructure.Application.Interface
{
    public interface ICafe : IBaseInterface<CafeM>
    {
        JsonResponse Add(CafeInDTO Cafe);
    }
}
