
namespace Rubns.WebAPI.Controllers.V1.Register
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RegisterController : ControllerBase
    {

        [HttpGet("Check")]
        public IActionResult Get() => Ok("Online");
    }
}
