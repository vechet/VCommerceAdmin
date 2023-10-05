using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class GetMeResponse : BaseResponse
    {
        public UserAccount UserAccount { get; set; }
        public GetMeResponse(UserAccount userAccount, int code, string msg)
        {
            UserAccount = userAccount;
            ErrorCode = code;
            ErrorMessage = msg;
        }
    }
}
