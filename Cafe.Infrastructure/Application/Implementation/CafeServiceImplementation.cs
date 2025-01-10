using AutoMapper;
using Cafe.Infrastructure.Application.Interface;

namespace Cafe.Infrastructure.Application.Implementation
{
    internal class CafeRepo : IBaseRepo<CafeM>, ICafe
    {
        private readonly IMapper _mapper;
        public CafeRepo(BaseContext<CafeContext> context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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
