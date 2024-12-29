
using Security.Infrastructure.Data;
using Security.Infrastructure.Domain.Users;

namespace Security.Infrastructure.Application.Implementation
{
    public class LoginUser : IBaseRepo<User>
    {
        private readonly SecurityContext _context;
        private readonly IMapper _mapper;
        public LoginUser(SecurityContext context, IMapper _mapper) : base(context)
        {
            this._mapper = _mapper;
            _context = context;
        }
        public async Task<JsonResponse> Login(LoginDTO profile)
        {

            JsonResponse response = new JsonResponse();

            try
            {
                string passwordhash = Implementation.Helpers.PasswordHash.HashedPassword(profile.Password);
                User user = _context.Users.Where(
                   x => x.Email == profile.UserName
                   && x.Password == passwordhash
                   ).FirstOrDefault()!;
                if (user != null)
                {
                    return response.SuccessResponse();
                }
                else
                {
                    return response.BadRequest("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                return response.ServerError(ex);
            }

        }
    }
}
