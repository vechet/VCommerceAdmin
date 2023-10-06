using VCommerceAdmin.ApiModels.Authentication;
using VCommerceAdmin.Repository.Interface;

namespace VCommerceAdmin.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public GetMeResponse GetMe()
        {
            throw new NotImplementedException();
        }

        public LoginResponse Login(LoginRequest req)
        {
            throw new NotImplementedException();
        }

        public RefreshTokenResponse RefreshToken()
        {
            throw new NotImplementedException();
        }

        public RegisterResponse Register(RegisterRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
