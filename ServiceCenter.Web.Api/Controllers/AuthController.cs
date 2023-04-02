using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Web.Api.AuthService;
using ServiceCenter.Web.Api.Models;

namespace ServiceCenter.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly TokenService tokenService;
    
    public AuthController(UserManager<IdentityUser> userManager, TokenService tokenService)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
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

    [HttpPost("login")]
    public async ValueTask<ActionResult<AuthResponse>> Authenticate(
        [FromBody] AuthRequest request)
    {
        var managedUser = await this.userManager.FindByEmailAsync(request.Email);
        if (managedUser == null)
        {
            return BadRequest(new { message = "Invalid credentials" });
        }
        
        var passwordIsValid = await this.userManager.CheckPasswordAsync(
            managedUser, request.Password);

        if (!passwordIsValid)   
        {
            return BadRequest(new { message = "Invalid credentials" });
        }
        
        var token = this.tokenService.CreateToken(managedUser);
        
        return new AuthResponse
        {
            Username = managedUser.UserName,
            Email = managedUser.Email,
            Token = token
        };
    }
    
}