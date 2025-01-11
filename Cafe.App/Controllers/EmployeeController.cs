





namespace Cafe.App.Controllers
{
    [Route("api/[controller]")]

    public class EmployeeController : BaseController<EmployeeDTO, EmployeeDTO>
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        public override Task<JsonResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Get(string id)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                response = await _employee.GetByIdAsync(int.Parse(id));

            }
            catch (Exception ex)
            {
                response.ServerError(ex);
            }
            return response;
        }

        public override async Task<JsonResponse> Get()
        {
            throw new NotImplementedException();
        }

        public override  async Task<JsonResponse> Patch([FromBody] EmployeeDTO obj)
        {
            throw new NotImplementedException();
        }

        public override async Task<JsonResponse> Post([FromBody] EmployeeDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
