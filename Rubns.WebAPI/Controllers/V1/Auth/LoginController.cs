
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
        public IActionResult LogIn(LoginRequestDTO loginRequest)
        {

            var result = PostLogIn.LogIn(loginRequest);

            return BadRequest();
        }
    }
}
