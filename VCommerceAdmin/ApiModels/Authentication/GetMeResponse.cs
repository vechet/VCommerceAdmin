using VCommerceAdmin.Helpers;
using VCommerceAdmin.Models;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class GetMeResponse : BaseResponse
    {
        public UserAccount User { get; set; }
        public GetMeResponse(UserAccount user, int code, string msg)
        {
            User = user;
            Code = code;
            Message = msg;
        }
    }
}
