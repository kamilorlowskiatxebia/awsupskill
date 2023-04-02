using Microsoft.AspNetCore.Mvc;
using Upskill.AwsApi.Models;
using Upskill.Contracts.Definitions;

namespace Upskill.AwsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ILogger<ImagesController> _logger;
        private readonly IImageFilter _filter;

        public ImagesController(ILogger<ImagesController> logger, IImageFilter filter)
        {
            _logger = logger;
            _filter = filter;
        }

        [HttpGet("hello")]
        public string SayHello()
        {
            return "Hello!";
        }

        [HttpPost("filter/greyscale")]
        public ApiImage Process()
        {
            
            throw new NotImplementedException();
        }
    }
}