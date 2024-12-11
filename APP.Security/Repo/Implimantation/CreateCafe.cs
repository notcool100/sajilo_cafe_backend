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
using APP.Security.Models.Cafe;
using APP.Security.Repo.Data;
using APP.Security.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Net;
using APP.Security.Models.Staff;

namespace APP.Security.Repo.Implimantation
{
    public class CreateCafe : ICreateCafe
    {
        private readonly SajiloDevContext _context;
        public CreateCafe(SajiloDevContext context)
        {
            _context = context;
        }
        public JsonResponse Create_Cafe(CreateCafeDTO createCafe)
        {
          
            JsonResponse response = new JsonResponse();

            try
            {

                var password = HashedPassword(createCafe.Password);
                var Cafe = new CafeM
                {
                    Cafename = createCafe.CafeName,
                    CafeLogo = createCafe.CafeLogo,
                    Address = createCafe.CafeAddress,
                    Subscriptionid = createCafe.Subscriptionid


                };
                _context.Cafe.Add(Cafe);
                _context.SaveChanges();
                int newCafeId = Cafe.Cafeid;
                var users = new Cafestaff
                {
                    Cafeid = newCafeId,
                    Name=createCafe.StaffName,
                    password=password,
                    phoneNo=createCafe.PhoneNo,
                };
                _context.Cafestaffs.Add(users);
                _context.SaveChanges();
                int staffid = users.Staffid;
                if(staffid != 0)
                {
                    response.ResponseData = staffid;
                    response.Message = "Cafe created Sucessfully";
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
        internal string HashedPassword(string password) {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

    }
}
