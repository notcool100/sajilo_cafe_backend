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

namespace APP.Security.Repo.Implimantation
{
    public class LoginUser: ILoginUser
    {
        private readonly IConfiguration _configuration;
        public LoginUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<JsonResponse>Login(ATTLoginUser profile)
        {
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "users.UserLogin";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("p_username", profile.cafe_id?.Trim());
                    param.Add("p_password", profile.password?.Trim());
                    param.Add("p_", profile.email?.Trim());
                    param.Add("p_auth_success", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    param.Add("p_user_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    param.Add("p_user_name", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);

                    // Execute the stored procedure
                    connection.Execute(sql, param, commandType: CommandType.StoredProcedure);

                     bool isAuthSuccessful = param.Get<bool>("p_auth_success");

                    if (isAuthSuccessful)
                    {
                        var userId = param.Get<int>("p_user_id");
                        var userName = param.Get<string>("p_user_name");

                        //var userProfile = new ATTUserProfile
                        //{
                        //    user_id = userId,
                        //    Username = userName,
                        //};

                        response.IsSuccess = true;
                        //response.ResponseData = userProfile;
                        response.Message = "Login Successful";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = ATTMessages.USER.LOGIN_FAILURE;
                    }
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
