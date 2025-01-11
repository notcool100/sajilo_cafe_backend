namespace Cafe.Infrastructure.Application.Implementation
{
    internal class EmployeeServiceImplimentation : IBaseRepo<CafeM,CafeContext>
    {
        public EmployeeServiceImplimentation(BaseContext<CafeContext> context) : base(context)
        {
        }

        public JsonResponse ViewEmployee(CafeM cafeId)
        {
            var employees = GetByIdAsync(cafeId);
            return new JsonResponse().SuccessResponse();
        }
    }
}
