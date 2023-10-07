using System.ComponentModel;

namespace VCommerceAdmin.Helpers
{
    public enum ApiReturnError
    {
        [Description("Internal Error")]
        DbError = -1,

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
    }
}