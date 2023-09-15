using Newtonsoft.Json;

namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, int code, string message)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
