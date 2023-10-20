namespace DesafioBaltaIO.Domain.Identity.Models
{

    public class LoginResponseModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenModel UserToken { get; set; }
    }
}
