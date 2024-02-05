using System.ComponentModel;

namespace VCommerceAdmin.Helpers
{
    public enum ApiResponseStatus
    {
        [Description("Internal Error")]
        InternalError = 500,

        [Description("Success")]
        Success = 0,

        [Description("Invalid Request Parameter")]
        InvalidParameter = 101,

        [Description("Invalid Password Format")]
        InvalidPasswordFormat = 102,

        [Description("Duplicate Name")]
        DuplicateName = 114,

        [Description("General Error")]
        GeneralError = 999,

        //Login
        [Description("Wrong Username Or Password")]
        WrongUserNameOrPassword = 200,

        [Description("Not found")]
        NotFound = 404,

        [Description("This resource has been deleted")]
        Gone = 410,

        [Description("Unauthorized")]
        Unauthorized = 401,

        [Description("Method Not Allow")]
        MethodNotAllow = 405,
    }
}