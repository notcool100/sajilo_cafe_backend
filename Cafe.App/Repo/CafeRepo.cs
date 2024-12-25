using App.Shared.Models;
using Cafe.Infrastructure.Domain;
using Cafe.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;


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
