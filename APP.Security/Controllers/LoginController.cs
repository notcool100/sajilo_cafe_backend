

namespace Security.App.Controllers
{
    public class LoginController:BaseController
    {
        private readonly ILoginUser _loginUser;
        public LoginController(ILoginUser loginUser)
        {
            _loginUser = loginUser;
        }
        [HttpPost]
        [Route("login")]
        public async Task<JsonResponse> Login([FromBody] LoginDTO login)
        {
            return await _loginUser.Login(login);
        }
    }
}
