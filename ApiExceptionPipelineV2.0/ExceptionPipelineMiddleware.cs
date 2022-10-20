using ApiExceptionPipelineV2._0.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace ApiExceptionPipelineV2._0
{
    public class ExceptionPipelineMiddleware
    {
        private readonly RequestDelegate _next;

        private ExceptionService? _exceptionService;
        private Dictionary<Enum, (string, HttpStatusCode)> _exceptionDecoder;
        private Dictionary<Type, Func<Exception>> _exceptionMaps = new();

        public ExceptionPipelineMiddleware(
            RequestDelegate next,
            Dictionary<Enum, (string, HttpStatusCode)> exceptionDecoder,
            Dictionary<Type, Func<Exception>> exceptionMaps
        )
        {
            _next = next;
            _exceptionDecoder = exceptionDecoder;
            _exceptionMaps = exceptionMaps;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _exceptionService = new ExceptionService(context, _exceptionDecoder);
            
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next.Invoke(context);
            }
            catch(Exception exception)
            {
                if (_exceptionMaps.ContainsKey(exception.GetType()))
                {
                    exception = _exceptionMaps[exception.GetType()]();
                }

                var response = _exceptionService.CreateResponseObject(exception);
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(response)
                );
            }
        }
    }
}