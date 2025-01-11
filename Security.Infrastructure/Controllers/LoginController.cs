
namespace Security.App.Controllers
{
    public class LoginController : BaseController<LoginDTO, JsonResponse>
    {
        private readonly ILoginUser _loginUser;
        public LoginController(ILoginUser loginUser)
        {
            _loginUser = loginUser;
        }

        public override Task<JsonResponse> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<JsonResponse> Get()
        {
            throw new NotImplementedException();
        }

        public override Task<JsonResponse> Get(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("login")]
        public async Task<JsonResponse> Login([FromBody] LoginDTO login)
        {
            return await _loginUser.Login(login);
        }

        public override Task<JsonResponse> Patch([FromBody] LoginDTO obj)
        {
            throw new NotImplementedException();
        }

        public override Task<JsonResponse> Post([FromBody] LoginDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
