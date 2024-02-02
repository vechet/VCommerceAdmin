using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class LoginResponse : BaseResponse
    {
        public LoginResponse() { }
        public LoginToken UserToken { get; set; }
        public LoginResponse(LoginToken userToken, int code, string msg)
        {
            UserToken = userToken;
            Code = code;
            Message = msg;
        }
    }
}
