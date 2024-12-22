using APP.COMMON;
using APP.Security.Repo.Data;

namespace App.Security.Repo.Interface
{
    public interface ILoginUser
    {
        public Task<JsonResponse> Login(LoginDTO login);
    }
}
