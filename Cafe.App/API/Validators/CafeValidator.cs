using Cafe.Infrastructure.Domain;
using Cafe.Infrastructure.Domain.Validators;

namespace Cafe.App.API.Validators
{
    public  class CafeValidator :CafeMValidator
    {
        public  bool ValidateCafe(CafeInDTO cafe)
        {
            if (string.IsNullOrEmpty(cafe.CafeName) || string.IsNullOrEmpty(cafe.CafeAddress) || string.IsNullOrEmpty(cafe.Password))
            {
                return false;
            }
            return true;
        }
    }
}
