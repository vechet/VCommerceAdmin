using VCommerceAdmin.ApiModels.Authentication;

namespace VCommerceAdmin.Services.Interface
{
    public interface IAuthenticationService
    {
        LoginResponse Login(LoginRequest req);
        RegisterResponse Register(RegisterRequest req);
        GetMeResponse GetMe();
        RefreshTokenResponse RefreshToken();
    }
}
