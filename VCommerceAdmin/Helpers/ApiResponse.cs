using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T> where T : IResponse
    {
        public ApiResponse(T data)
        {
            Data = data;
            ErrorCode = (ApiReturnError)data.ErrorCode;
        }

        public T Data { get; set; }

        public ApiReturnError ErrorCode { get; set; }

        public string Message => ErrorCode.Description();
    }

    public class BaseResponse : IResponse
    {
        public BaseResponse() { }

        public BaseResponse(int id, int code, string msg)
        {
            Id = id;
            ErrorCode = code;
            ErrorMessage = msg;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        [JsonIgnore]
        public int ErrorCode { get; set; }
        [JsonIgnore]
        public string ErrorMessage { get; set; }
    }

    public interface IResponse
    {
        int ErrorCode { get; set; }
        string ErrorMessage { get; set; }
    }
}