namespace EduAPI.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        private static readonly Serilog.ILogger _logger = Log.ForContext<ExceptionHandlerMiddleware>();

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { await next.Invoke(context); }
            catch (ResourceNotFoundException resourceNotFoundException)
            {
                await HandleExceptionAsync(context, resourceNotFoundException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }
            
            catch (Exception exception)
            {

                _logger.Error($"({DateTime.Now}) Unhandled Exception: {context.Request.Method}: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n\n{exception.Message}\n{exception}");
                await HandleExceptionAsync(context, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            _logger.Error("Caught exception: " + exception.Message);
            return context.Response.WriteAsJsonAsync(new { Error = exception.Message });
        }
    }
}