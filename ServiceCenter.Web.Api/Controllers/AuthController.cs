using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    
    public AuthController(UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
    }
    
    [HttpPost("register")]
    public async ValueTask<IActionResult> Register(
        [FromBody] RegistrationRequest request)
    {
        var user = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Email
        };
        
        var result = await this.userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return this.BadRequest(result.Errors);
        }
        
        return this.Ok();
    }
}