using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginRequest req);
        Task<BaseResponse> Register(RegisterRequest req);
        Task<GetMeResponse> GetMe();
        Task<RefreshTokenResponse> RefreshToken();
    }
}
