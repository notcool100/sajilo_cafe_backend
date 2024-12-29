namespace Security.Infrastructure.Application.Interface
{
    public interface ISecurityCommon
    {
        public string HashPassword(string password);
    }
}
