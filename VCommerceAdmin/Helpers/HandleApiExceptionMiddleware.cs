using Newtonsoft.Json;

namespace VCommerceAdmin.Helpers
{
    public class HandleApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == ApiResponseStatus.Unauthorized.Value())
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ApiResponseStatus.Unauthorized.Value();

                var errorResponse = new
                {
                    code = ApiResponseStatus.Unauthorized.Value(),
                    message = ApiResponseStatus.Unauthorized.Description()
                };

                var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(jsonErrorResponse);
            }
            else if (context.Response.StatusCode == ApiResponseStatus.MethodNotAllow.Value())
            {
                if (context.Response.StatusCode == ApiResponseStatus.MethodNotAllow.Value())
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = ApiResponseStatus.MethodNotAllow.Value();

                    var errorResponse = new
                    {
                        code = ApiResponseStatus.MethodNotAllow.Value(),
                        message = ApiResponseStatus.MethodNotAllow.Description()
                    };

                    var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(jsonResponse);
                }
            }

        }
    }

}
