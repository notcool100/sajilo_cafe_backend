
namespace Cafe.App.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("GetAllEmployByCafe")]
        public JsonResponse GetAllEmployByCafe(int CafeId)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = _employee.GetByIdAsync(CafeId);

            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }

    }
}
