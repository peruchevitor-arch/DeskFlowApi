using Microsoft.AspNetCore.Http;

namespace Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
    }
}