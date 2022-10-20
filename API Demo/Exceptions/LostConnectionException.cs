using ApiExceptionPipelineV2._0.Entities;

namespace API_Demo.Exceptions
{
    public class LostConnectionException : BaseException
    {
        public LostConnectionException() : base(ExceptionType.LostConnectionToServer)
        {
        }
    }
}
