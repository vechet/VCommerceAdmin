using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T> where T : IResponse
    {
        private T _data;
        private ApiReturnError _errCode = ApiReturnError.GeneralError;

        public ApiResponse(T data)
        {
            _data = data;
            _errCode = (ApiReturnError)data.ErrorCode;
        }

        public T Data
        {
            get => _data;
            set => _data = value;
        }

        public ApiReturnError ErrorCode
        {
            get => _errCode;
            set => _errCode = value;
        }

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