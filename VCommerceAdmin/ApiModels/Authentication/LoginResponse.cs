using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse() { }
        public TokenResponse UserToken { get; set; }
        public LoginResponse(TokenResponse userToken, int code, string msg)
        {
            UserToken = userToken;
            Code = code;
            Message = msg;
        }
    }
}
