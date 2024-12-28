

namespace Security.App.Application.Interface
{
    public interface ILoginUser : IBaseInterface<User>
    {
        public Task<JsonResponse> Login(LoginDTO login);
    }
}
