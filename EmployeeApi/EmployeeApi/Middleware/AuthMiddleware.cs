using System.Net;

namespace TallerCodeChallengeApi.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private const string HeaderName = "X-Auth-Token";
    private const string Token  = "token-123";

    public AuthMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var token) || token != Token)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { error = $"Unauthorized. Provide header {HeaderName}." });
                return;
            }
        }

        await _next(context);
    }
}