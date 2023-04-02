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

        public ImagesController(ILogger<ImagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public string SayHello()
        {
            return "Hello!";
        }

        [HttpPost("filter/greyscale")]
        public ApiImage Process(IFormFile imageFile)
        {
            using var readStream = imageFile.OpenReadStream();
            using var memoryStream = new MemoryStream();
            
            readStream.CopyTo(memoryStream);
            var rawData = memoryStream.ToArray();

            return new ApiImage();
        }
    }
}