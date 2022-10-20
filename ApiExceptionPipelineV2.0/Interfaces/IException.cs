using System.Net;

namespace ApiExceptionPipelineV2._0.Interfaces
{
    internal interface IException
    {
        public HttpStatusCode StatusCode { get; set; }
        public Enum TypeCode { get; set; }
        public string Message { get; set; }
    }
}
