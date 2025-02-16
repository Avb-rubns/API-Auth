
namespace Rubns.WebAPI.Controllers.V1.Register
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RegisterController : ControllerBase
    {
        IRegisterInputPort RegisterInputPort { get; }

        public RegisterController(IRegisterInputPort registerInputPort)
        {
            RegisterInputPort = registerInputPort;
        }

        [HttpGet("Check")]
        public IActionResult Get() => Ok("Online");

        [HttpPost("RegisterApp")]
        public async Task<IActionResult> RegisterAppAsync(RegisterDTO register)
        {
            await RegisterInputPort.RegisterAppAsync(register);
            return Ok();
        }
    }
}
