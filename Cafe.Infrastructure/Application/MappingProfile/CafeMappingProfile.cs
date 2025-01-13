namespace Cafe.Infrastructure.Application.MappingProfile
{
    using AutoMapper;
    using Cafe.Infrastructure.Application.DTOs;
    using Cafe.Infrastructure.Domain.Modals.Cafe;

    public class CafeMappingProfile : Profile
    {
        public CafeMappingProfile()
        {
            // Defining the mapping between CafeInDTO and CafeM using profile
            CreateMap<CafeInDTO, CafeM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CafeName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.CafeAddress))
                .ForMember(dest => dest.Subscriptionid, opt => opt.MapFrom(src => src.Subscriptionid))
                .ForMember(dest => dest.CafeLogo, opt => opt.MapFrom(src => src.CafeLogo))
                .ForMember(dest => dest.Employees, opt => opt.Ignore()); // Ignoring the Employees collection as it will be handled separately
        }
    }
}
