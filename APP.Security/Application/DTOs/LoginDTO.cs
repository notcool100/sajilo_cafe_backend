namespace Security.App.Application.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Phone_no { get; set; }
        public string Password { get; set; }
        public bool Remember_me { get; set; }
    }
}
