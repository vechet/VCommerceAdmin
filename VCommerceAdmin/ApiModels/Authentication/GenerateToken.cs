namespace VCommerceAdmin.ApiModels.Authentication
{
    public class GenerateToken
    {
        public string Token {get; set;} = null!;
        public string ExpiresIn {get; set; } = null!;
    }
}
