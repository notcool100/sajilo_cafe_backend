namespace Cafe.App.Interface
{
    public interface ICafe : IBaseInterface<CafeM>
    {
        JsonResponse Add(CafeInDTO Cafe);
    }
}
