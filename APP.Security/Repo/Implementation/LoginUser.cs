using APP.COMMON;
using APP.Security.Models;
using APP.Security.Repo.Data;
using APP.Security.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace App.Security.Repo.Implementation
{
    public class LoginUser : ILoginUser
    {
        private readonly CafeContext _context;
        private readonly ISecurityCommon _securityCommon;
        public LoginUser(CafeContext context, ISecurityCommon Securitycommon)
        {
            _context = context;
            _securityCommon = Securitycommon;
        }
        public async Task<JsonResponse> Login(LoginDTO profile)
        {

            JsonResponse response = new JsonResponse();

            try
            {
                using var transaction = _context.Database.BeginTransaction();

                var Hashpassword = _securityCommon.HashPassword(profile.password);
                var UserDetail = _context.Cafestaffs.SingleOrDefaultAsync(
                    m => m.password == Hashpassword
                    &&m.email==profile.email);
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
