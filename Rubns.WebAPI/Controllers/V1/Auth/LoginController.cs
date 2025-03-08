namespace Rubns.WebAPI.Controllers.V1.Auth
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoginController : ControllerBase
    {
        IPostLogInPort<JWT> PostLogIn { get; }

        public LoginController(IPostLogInPort<JWT> postLogIn)
        {
            PostLogIn = postLogIn;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginRequestDTO loginRequest)
        {

            var result = await PostLogIn.LogIn(loginRequest);

            if (result is not null)
                return Ok(result);

            return Unauthorized(new { message = "Credenciales incorrectas." });
        }
    }
}
