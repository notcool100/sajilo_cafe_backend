namespace Cafe.Infrastructure.Domain.Validators
{
    public class CafeMValidator
    {
        public bool ValidateCafeM(CafeM cafe)
        {
            if (string.IsNullOrEmpty(cafe.CafeName) || string.IsNullOrEmpty(cafe.CafeAddress) || string.IsNullOrEmpty(cafe.Password))
            {
                return false;
            }
            return true;
        }
    }
}
