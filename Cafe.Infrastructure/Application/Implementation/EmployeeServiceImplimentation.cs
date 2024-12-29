namespace Cafe.Infrastructure.Application.Implementation
{
    internal class EmployeeServiceImplimentation : IBaseRepo<CafeM>
    {
        public EmployeeServiceImplimentation(DbContext context) : base(context)
        {
        }

        public JsonResponse ViewEmployee(CafeM cafeId)
        {
            var employees = GetByIdAsync(cafeId);
            return new JsonResponse().SuccessResponse();
        }
    }
}
