using APP.COMMON;
using APP.Security.Models;
using APP.Security.Repo.Common;
using APP.Security.Repo.Data;
using APP.Security.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace APP.Security.Repo.Implimantation
{
    public class LoginUser : ILoginUser
    {
        private readonly SajiloDevContext _context;
        public LoginUser(SajiloDevContext context)
        {
            _context = context;
        }
        public async Task<JsonResponse> Login(LoginDTO profile)
        {
            var response = new JsonResponse();

            try
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();

                var hashPassword = PasswordHash.HashedPassword(profile.password);

                var userDetail = await _context.Cafestaffs
                    .SingleOrDefaultAsync(m => m.password == hashPassword && m.phoneNo == profile.Phone_no);

                if (userDetail != null)
                {
                    response.IsSuccess = true;
                    response.HasError = false;
                    response.Message = "Login successful.";
                    response.ResponseData = userDetail;
                }
                else
                {
                    response.IsSuccess = false;
                    response.HasError = true;
                    response.Message = "Invalid email or password.";
                }

                await transaction.CommitAsync();
            }
            catch (SqlException sqlEx)
            {
                response.IsSuccess = false;
                response.HasError = true;
                response.Message = $"Database error: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.HasError = true;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }

    }
}
