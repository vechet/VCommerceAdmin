using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T> where T : IResponse
    {
        public ApiResponse(T data)
        {
            Data = data;
            Code = (ApiResponseStatus)data.Code;
        }

        public ApiResponseStatus Code { get; set; }

        public string Message => Code.Description();

        public T Data { get; set; }
    }

    public class BaseResponse : IResponse
    {
        public BaseResponse() { }

        public BaseResponse(int id, int code, string msg)
        {
            Id = id;
            Code = code;
            Message = msg;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        [JsonIgnore]
        public int  Code { get; set; }
        [JsonIgnore]
        public string Message { get; set; }
    }

    public interface IResponse
    {
        int Code { get; set; }
        string Message { get; set; }
    }
}