namespace WebApplicationState.Middleware
{
    public class CustomMiddleware
    {
        private RequestDelegate _next;

        public static readonly Object myCustomMiddlewareKey = new object();

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items[myCustomMiddlewareKey] = "hello";
            await _next(httpContext);
        }
    }

    public static class CustomMiddlewareExtantions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomMiddleware>();
        }
    }
}
