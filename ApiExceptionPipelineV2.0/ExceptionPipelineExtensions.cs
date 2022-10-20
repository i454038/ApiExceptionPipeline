using Microsoft.AspNetCore.Builder;
using System.Net;

namespace ApiExceptionPipelineV2._0
{
    public static class ExceptionPipelineExtensions
    {
        public static IApplicationBuilder UseCustomExceptionPipeline(
            this IApplicationBuilder builder,
            Dictionary<Enum, (string, HttpStatusCode)> exceptionDecoder,
            Dictionary<Type, Func<Exception>> exceptionMaps
        )
        {
            return builder.UseMiddleware<ExceptionPipelineMiddleware>(exceptionDecoder, exceptionMaps );
        }
    }
}
