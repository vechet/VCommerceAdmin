namespace VCommerceAdmin.Helpers
{
    public class ApiResponse<T>
    {
        private T _data;

        public ApiResponse(T data)
        {
            _data = data;
        }

        public ErrorResponse Error { get; set; } = null!;
        public T Data
        { 
            get => _data;
            set => _data = value;
        }
    }

    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
    }
}
