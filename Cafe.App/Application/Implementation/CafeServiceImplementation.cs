using AutoMapper;
using Cafe.Infrastructure.Application;

namespace Cafe.App.Repo
{
    internal class CafeRepo : IBaseRepo<CafeM>
    {
        private readonly IMapper _mapper;
        public CafeRepo(CafeContext context,IMapper _mapper) : base(context)
        {
            this._mapper = _mapper;
        }

        public override void Add(CafeM entity)
        {

            base.Add(entity);
        }
        public JsonResponse Add(CafeInDTO dto)
        {
           CafeM cafe= _mapper.Map<CafeInDTO, CafeM>(dto);
            // all validation before add
            this.Add(cafe);
            // adding owner in staff table
            if (!string.IsNullOrEmpty(dto.StaffName) && !string.IsNullOrEmpty(dto.Password))
            {

                Employee staff = new Employee(dto.StaffName, dto.Email, dto.Password, dto.PhoneNo, cafe, cafe.EntryBy);
                Context.Set<Employee>().Add(staff);
            }
            Context.SaveChanges();
            return new JsonResponse().SuccessResponse();
        }
    }
}
