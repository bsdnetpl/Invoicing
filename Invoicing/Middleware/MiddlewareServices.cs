
namespace Invoicing.Middleware
{
    public class MiddlewareServices : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
