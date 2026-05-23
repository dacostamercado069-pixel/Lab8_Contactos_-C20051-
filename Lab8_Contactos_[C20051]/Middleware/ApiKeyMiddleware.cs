namespace Lab8_Contactos_C20051.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HEADER_API_KEY = "x-api-key";
        private const string API_KEY_VALIDA = "contactos-api-key-2024";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS")
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(HEADER_API_KEY, out var apiKeyRecibida))
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"error\": \"No autorizado\"}");
                return;
            }

            if (apiKeyRecibida != API_KEY_VALIDA)
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"error\": \"API Key incorrecta\"}");
                return;
            }

            await _next(context);
        }
    }
}
