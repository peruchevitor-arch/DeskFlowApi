using Microsoft.AspNetCore.Http;

namespace DeskFlowApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            
            try 
            {
             await _next(context);
            }
            catch (KeyNotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 404;
                var resposta = new
                {
                    status = 404,
                    message = ex.Message,
                };
                await context.Response.WriteAsJsonAsync(resposta);
            }
            catch (InvalidOperationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                var resposta = new
                {
                    status = 400,
                    message = ex.Message,
                };
                await context.Response.WriteAsJsonAsync(resposta);
               
            }
            catch (Exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var resposta = new
                {
                    status = 500,
                    message = "Ocorreu um erro interno no servidor.",
                };
                await context.Response.WriteAsJsonAsync(resposta);
                
            }
        }
        }
    }