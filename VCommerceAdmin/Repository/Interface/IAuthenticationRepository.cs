using VCommerceAdmin.ApiModels.Authentication;

namespace VCommerceAdmin.Repository.Interface
{
    public interface IAuthenticationRepository
    {
        LoginResponse Login(LoginRequest req);
        RegisterResponse Register(RegisterRequest req);
        GetMeResponse GetMe();
        RefreshTokenResponse RefreshToken();
    }
}
