using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class RefreshTokenResponse : BaseResponse
    {
        public RefreshTokenResponse() { }
        public TokenResponse UserToken { get; set; }
        public RefreshTokenResponse(TokenResponse userToken, int code, string msg)
        {
            UserToken = userToken;
            Code = code;
            Message = msg;
        }
    }
}
