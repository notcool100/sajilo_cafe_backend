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
using APP.Security.Repo.Interface;
using Npgsql;
using APP.Security.Models.Users;

namespace APP.Security.Repo.Implimantation
{
    public class CreateCafe : ICreateCafe
    {
        private readonly IConfiguration _configuration;
        public CreateCafe(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JsonResponse Create_Cafe(SecUser createCafe)
        {
            var connectionString = _configuration["ConnectionStrings:DBSettingConnection"];
            JsonResponse response = new JsonResponse();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                   connection.Open();

                    string sql = "SELECT * FROM core.create_cafe(@p_subscription_id, @p_cafe_name, @p_cafe_address, @p_owner_name, @p_owner_email, @p_owner_password)";

                    var param = new DynamicParameters();
                    //param.Add("p_subscription_id", createCafe.subscriptionId);
                    //param.Add("p_cafe_name", createCafe.cafeName?.Trim());
                    //param.Add("p_cafe_address", createCafe.cafeAddress?.Trim());
                    //param.Add("p_owner_name", createCafe.AdminName?.Trim());
                    //param.Add("p_owner_email", createCafe.AdminEmail?.Trim());
                    //param.Add("p_owner_password", createCafe.AdminPassword);

                    var result =  connection.QuerySingleOrDefault(sql, param, commandType: CommandType.Text);

                    if (result != null)
                    {
                        var userId = result.UserId;     
                        var userName = result.Username;
                        var email = result.Email;
                        var fullName = result.FullName;
                        var cafeId = result.CafeId;
                        var cafeName = result.CafeName;

                        response.IsSuccess = true;
                        response.Message = "Cafe created successfully";
                        //response.ResponseData = new
                        //{
                        //    userId,
                        //    userName,
                        //    email,
                        //    fullName,
                        //    cafeId,
                        //    cafeName
                        //};
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Failed to create cafe or user.";
                    }
                }
            }
            catch (PostgresException pgEx)
            {
                response.IsSuccess = false;
                response.HasError = true;
                response.Message = $"Database error: {pgEx.Message}";
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
