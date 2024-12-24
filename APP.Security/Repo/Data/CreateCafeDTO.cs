using System.Text.Json.Serialization;

namespace APP.Security.Repo.Data
{
    public class CreateCafeDTO
    {
        public string CafeName { get; set; }
        public string CafeAddress { get; set; }
        public string StaffName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNo { get; set; }
        public int? Subscriptionid { get; set; }
        public byte[]? CafeLogo { get; set; }
        [JsonIgnore]
        public string TransactionUser { get; set; }
    }
}
