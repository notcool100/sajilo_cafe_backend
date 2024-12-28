using AutoMapper;

namespace Cafe.Infrastructure.Application.Implementation
{
    internal class CafeRepo : IBaseRepo<CafeM>
    {
        private readonly IMapper _mapper;
        public CafeRepo(CafeContext context, IMapper _mapper) : base(context)
        {
            this._mapper = _mapper;
        }

        public override void Add(CafeM entity)
        {

            base.Add(entity);
        }
        public JsonResponse Add(CafeInDTO dto)
        {
            CafeM cafe = _mapper.Map<CafeInDTO, CafeM>(dto);
            // all validation before add
            Add(cafe);
            // adding owner in staff table
            if (!string.IsNullOrEmpty(dto.StaffName) && !string.IsNullOrEmpty(dto.Password))
            {

                Employee staff = new Employee(dto.StaffName, dto.Email, dto.Password, dto.PhoneNo, cafe, cafe.EntryBy);
                _ = Context.Set<Employee>().Add(staff);
            }
            _ = Context.SaveChanges();
            return new JsonResponse().SuccessResponse();
        }
    }
}
