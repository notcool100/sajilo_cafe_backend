namespace APP.Security.Repo.Data
{
    public class LoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool remember_me { get; set; }
    }
}
