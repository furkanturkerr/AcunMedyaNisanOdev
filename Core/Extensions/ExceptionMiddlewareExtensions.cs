using Core.Exceptions.Handlers;
using Microsoft.AspNetCore.Builder;

namespace Core.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}