using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using APP.COMMON;
using Dapper;
using APP.Security.Models.Users;
using APP.Security.Repo.Data;
using APP.Security.Models;
using APP.Security.Repo.Interface;
using APP.Security.Models.Staff;
using Microsoft.EntityFrameworkCore;

namespace APP.Security.Repo.Implimantation
{
    public class LoginUser: ILoginUser
    {
        private readonly SajiloDevContext _context;
        private readonly ISecurityCommon _securityCommon;
        public LoginUser(SajiloDevContext context,ISecurityCommon Securitycommon)
        {
            _context = context;
            _securityCommon = Securitycommon;
        }
        public Task<JsonResponse>Login(LoginDTO profile)
        {
            
            JsonResponse response = new JsonResponse();
            
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {

                    var Hashpassword = _securityCommon.HashPassword(profile.password);
                   var UserDetail =_context.Cafestaffs.SingleOrDefaultAsync(m=>m.password == Hashpassword&&m=>m.e);
                  
                }
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

            return Task.FromResult(response);
        }
    }
}
