namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T>
    {

        public ApiResponse(T data)
        {
            Data = data;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get;  set; }
    }

    public interface IResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
