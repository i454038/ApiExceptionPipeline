using ApiExceptionPipelineV2._0.Interfaces;
using System.Net;

namespace ApiExceptionPipelineV2._0.Entities
{
    public abstract class BaseException : Exception, IException
    {
        public HttpStatusCode StatusCode { get; set; }
        public Enum TypeCode { get; set; }
        public new string Message { get; set; }

        public BaseException(Enum typeCode)
        {  
            var (message, statusCode) = ExceptionService.ExceptionDecoder[typeCode];
            TypeCode = typeCode;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
