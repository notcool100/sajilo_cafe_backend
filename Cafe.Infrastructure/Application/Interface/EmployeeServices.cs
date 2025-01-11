namespace Cafe.Infrastructure.Application.Interface
{
    public interface IEmployee : IBaseInterface<Employee,CafeContext>
    {
        Task<JsonResponse> GetByIdAsync(int CafeId);
    }
}
