using API_Demo.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        [HttpGet("TrySystemException")]
        public Task TrySystemException()
        {
            throw new Exception();
        }

        [HttpGet("TryCustomException")]
        public Task TryCustomException()
        {
            throw new LostConnectionException();
        }

        [HttpGet("TryMappedException")]
        public Task TryMappedException()
        {
            throw new DbUpdateException();
        }
    }
}