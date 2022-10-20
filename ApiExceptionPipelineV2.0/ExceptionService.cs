using ApiExceptionPipelineV2._0.Entities;
using ApiExceptionPipelineV2._0.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ApiExceptionPipelineV2._0
{
    internal class ExceptionService
    {
        private HttpContext _context;

        public static Dictionary<Enum, (string, HttpStatusCode)> ExceptionDecoder = new();
        internal ExceptionService(HttpContext context, Dictionary<Enum, (string, HttpStatusCode)> exceptionDecoder)
        {
            _context = context;
            ExceptionDecoder = exceptionDecoder;
        }

        internal ExceptionViewModel CreateResponseObject(Exception exception)
        {

            _context!.Response.ContentType = "application/json";

            ExceptionViewModel response = new ExceptionViewModel
            {
                StatusCode = 500,
                Message = string.Empty,
            };

            var exceptionTypeName = exception.GetType()!.BaseType!.Name;

            switch(exceptionTypeName)
            {
                case nameof(BaseException):
                    response.StatusCode = (int)(exception as BaseException)!.StatusCode;
                    response.Message = (exception as BaseException)!.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An internal error accured. Please try again later";
                    break;
            }

            return response;


        }
    }
}
