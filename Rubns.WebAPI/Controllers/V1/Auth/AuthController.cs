
namespace Rubns.WebAPI.Controllers.V1.Auth
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        IRegisterInputPort RegisterInputPort { get; }
        IGenerateKeyPort<Response<string>> GenerateKeyPort { get; }

        public AuthController(IRegisterInputPort registerInputPort
            , IGenerateKeyPort<Response<string>> generateKeyPort)
        {
            RegisterInputPort = registerInputPort;
            GenerateKeyPort = generateKeyPort;
        }

        [HttpGet("check")]
        public IActionResult Get() => Ok("Online");

        [HttpPost("register-app")]
        public async Task<IActionResult> RegisterAppAsync(RegisterDTO register)
        {
            await RegisterInputPort.RegisterAppAsync(register);
            return Ok();
        }
        [HttpPost("generate-key")]
        public async Task<IActionResult> GenerateKey(RegisterDTO register)
        {
            var result = GenerateKeyPort.GenerateKey(register);
            return Ok(result);
        }
    }
}
