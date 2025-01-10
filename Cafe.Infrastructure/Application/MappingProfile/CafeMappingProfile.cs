namespace Cafe.Infrastructure.Application.MappingProfile
{
    public class CafeMappingProfile:Profile
    {
        public CafeMappingProfile()
        {
            // Defining the mapping between CafeInDTO and CafeM using profile
            CreateMap<CafeInDTO, CafeM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CafeName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.CafeAddress))
                //.ForMember(dest => dest.Subscriptionid, opt => opt.MapFrom(src => src.Subscriptionid))
              
                ;
        }
    }
}
