namespace Api.Controllers;

using Microsoft.AspNetCore.Mvc;

using Api.Models.Account;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [HttpPost()]
    [Route(nameof(SignIn))]
    public Task<IActionResult> SignIn(SignInData signInData)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpPost()]
    [Route(nameof(SignUp))]
    public Task<IActionResult> SignUp(SignUpData signUpData)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}
