
namespace Rubns.WebAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoginController : ControllerBase
    {
        IPostLogInPort<AuthResponseDTO> PostLogIn { get; }
        ILogOutPort LogOutPort { get; }

        public LoginController(IPostLogInPort<AuthResponseDTO> postLogIn
            , ILogOutPort logOut)
        {
            PostLogIn = postLogIn;
            LogOutPort = logOut;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginRequestDTO loginRequest)
        {

            var result = await PostLogIn.LogIn(loginRequest);

            if (result is not null)
                return Ok(result);

            return Unauthorized(new { message = "Credenciales incorrectas o usuario no registrado." });
        }
        [HttpPost("logout")]
        public async Task<IActionResult> LogOut(RefreshTokenRequestDTO refreshToken)
        {
            if (await LogOutPort.LogOut(refreshToken))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
