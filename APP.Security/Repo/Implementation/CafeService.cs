using APP.COMMON;
using APP.Security.Models;
using APP.Security.Models.Cafe;
using APP.Security.Repo.Data;
using GenericRepositoryEntityFramework;

namespace App.Security.Repo.Implementation
{
    public class CafeService : IBaseRepo<CafeM>
    {
        CafeContext _context;
        public CafeService(CafeContext context) : base(context)
        {
            _context = context;
        }

        // directly override the default function also 
        public override void Add(CafeM entity)
        {

            base.Add(entity);
        }
        public JsonResponse Add(CreateCafeDTO dto)
        {
            CafeM Cafe = new
            (
                dto.CafeName,
                dto.CafeAddress,
                dto.TransactionUser,
                dto.Subscriptionid,
                dto.CafeLogo
                );
            // all validation before add
            Add(Cafe);
            return new JsonResponse().SuccessResponse();
        }
    }
}
