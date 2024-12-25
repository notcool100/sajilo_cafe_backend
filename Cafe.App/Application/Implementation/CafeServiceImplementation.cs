using Shared.App;
using Cafe.Infrastructure.Domain;
using App.Shared.Infrastructure;


namespace Cafe.App.Repo
{
    public class CafeRepo:IBaseRepo<CafeM>
    {
        public CafeRepo(DbContext context) : base(context)
        {
        }

        public override void Add(CafeM entity)
        {

            base.Add(entity);
        }
        public JsonResponse Add(CreateCafeDTO dto)
        {
            CafeM cafe = new CafeM
            {
                Cafename = dto.CafeName,
                Address = dto.CafeAddress,
                Subscriptionid = dto.Subscriptionid,
                CafeLogo = dto.CafeLogo,
                Createdat = DateTime.UtcNow
            };
            // all validation before add
            Add(cafe);
            Context.SaveChanges();

            // adding owner in staff table
            if (!string.IsNullOrEmpty(dto.StaffName) && !string.IsNullOrEmpty(dto.Password))
            {
                Cafestaff staff = new Cafestaff
                {
                    Name = dto.StaffName,
                    password = dto.Password,
                    phoneNo = dto.PhoneNo,
                    email = dto.Email,
                    Cafeid = cafe.Cafeid 
                };

                Context.Set<Cafestaff>().Add(staff);
                Context.SaveChanges(); 
            }
            return new JsonResponse().SuccessResponse();
        }
    }
}
