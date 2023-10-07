using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Services.Interface
{
    public interface IAuthenticationService
    {
        LoginResponse Login(LoginRequest req);
        Task<BaseResponse> Register(RegisterRequest req);
        GetMeResponse GetMe();
        RefreshTokenResponse RefreshToken();
    }
}
