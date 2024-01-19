using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class RefreshTokenResponse : BaseResponse
    {
        public UserAccount UserAccount { get; set; }
        public RefreshTokenResponse(UserAccount userAccount, int code, string msg)
        {
            UserAccount = userAccount;
            Code = code;
            Message = msg;
        }
    }
}
