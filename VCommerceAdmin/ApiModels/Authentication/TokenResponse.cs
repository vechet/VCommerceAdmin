namespace VCommerceAdmin.ApiModels.Authentication
{
    public class TokenResponse
    {
        public TokenResponse() {}
        public TokenResponse(string accessToken, string expiresIn, string refreshToken, string refreshTokenExpiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            RefreshToken = refreshToken;
            RefreshTokenExpiresIn = refreshTokenExpiresIn;
        }
        public string AccessToken { get; set; } = null!;
        public string ExpiresIn { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string RefreshTokenExpiresIn { get; set; } = null!;
    }
}
