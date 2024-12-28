namespace Cafe.Infrastructure.Domain.Validators
{
    public class CafeMValidator
    {
        public bool ValidateCafeM(CafeM cafe)
        {
            if (string.IsNullOrEmpty(cafe.Name) || string.IsNullOrEmpty(cafe.Address))
            {
                return false;
            }
            return true;
        }
    }
}
