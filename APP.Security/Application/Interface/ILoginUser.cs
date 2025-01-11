

using Security.Infrastructure.Domain.Users;

namespace Security.Infrastructure.Application.Interface
{
    public interface ILoginUser : IBaseInterface<User, SecurityContext>
    {
        public Task<JsonResponse> Login(LoginDTO login);
    }
}
