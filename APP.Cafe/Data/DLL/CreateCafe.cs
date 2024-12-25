using App.Shared.Models;
using APP.Cafe.Data.Interface;
using APP.Cafe.Models;
using APP.Security.Models.Staff;
using Npgsql;

namespace APP.Cafe.Data
{
    public class CreateCafe : ICreateCafeDDL
    {
        private readonly SajiloDevContext _context;
        public CreateCafe(SajiloDevContext context)
        {
            _context = context;
        }
        public JsonResponse Create_Cafe_Ddl(CreateCafeDTO createCafe)
        {
          
            JsonResponse response = new JsonResponse();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                  
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
                        Name = createCafe.StaffName,
                        password = createCafe.Password,
                        phoneNo = createCafe.PhoneNo,
                    };
                    _context.Cafestaffs.Add(users);
                    _context.SaveChanges();
                    int staffid = users.Staffid;

                    if (staffid != 0)
                    {
                        response.ResponseData = staffid;
                        response.Message = "Cafe created Sucessfully";
                        transaction.Commit();
                        return response;
                    }


                }
                catch (PostgresException pgEx)
                {
                    transaction.Rollback();
                    response.IsSuccess = false;
                    response.HasError = true;
                    response.Message = $"Database error: {pgEx.Message}";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.IsSuccess = false;
                    response.HasError = true;
                    response.Message = $"An error occurred: {ex.Message}";
                  
                }
            }

            return response;
        }
      

    }
}
