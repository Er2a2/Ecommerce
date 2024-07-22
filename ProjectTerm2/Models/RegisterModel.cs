namespace ProjectTerm2.Models
{
    public class RegisterModel
    {
        public string Username {  get; set; }
        public string Password { get; set; }  
        public string Password2 { get; set; }  
        public string Firstname {  get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
