namespace VCommerceAdmin.ApiModels.Authentication
{
    public class LoginToken
    {
        public LoginToken() {}
        public LoginToken(string token, string expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
        public string Token { get; set; } = null!;
        public string ExpiresIn { get; set; } = null!;
    }
}
