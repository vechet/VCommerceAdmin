using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class LoginResponse : BaseResponse
    {
        public UserAccount UserAccount { get; set; }
        public LoginResponse(UserAccount userAccount, int code, string msg)
        {
            UserAccount = userAccount;
            Code = code;
            Message = msg;
        }
    }
}
