namespace Cafe.Infrastructure.Application.Interface
{
    public interface IEmployee : IBaseInterface<Employee>
    {
        JsonResponse GetByIdAsync(int CafeId);
    }
}
