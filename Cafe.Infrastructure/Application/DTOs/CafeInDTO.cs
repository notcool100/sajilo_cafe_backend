

namespace Cafe.Infrastructure.Application.DTOs;

public class CafeInDTO
{
    public string CafeName { get; set; }
    public string CafeAddress { get; set; }
    public string? StaffName { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNo { get; set; }
    public int? Subscriptionid { get; set; }
    public byte[]? CafeLogo { get; set; }
    public User TranUser { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            _ = CreateMap<CafeInDTO, CafeM>()
                .ForMember(x => x.Name, options => options.MapFrom(src => src.StaffName))
                ;
        }
    }
}
