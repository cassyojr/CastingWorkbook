using Asp.Versioning;
using CastingWorkbook.Api.Security;
using CastingWorkbook.Api.ViewModels;
using CastingWorkbook.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CastingWorkbook.Api.Controllers.Login.V1;

[AllowAnonymous]
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly TokenConfigurations _tokenConfigurations;

    public LoginController(IOptions<TokenConfigurations> tokenConfigurations, IUserRepository userRepository)
    {
        _tokenConfigurations = tokenConfigurations.Value;
        _userRepository = userRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (model is null)
            return BadRequest("Invalid username and password");

        if (string.IsNullOrWhiteSpace(model.UserName) || string.IsNullOrWhiteSpace(model.Password))
            return BadRequest("Invalid username and password");

        var user = await _userRepository.GetUserAsync(model.UserName, model.Password);

        if (user is null)
            return Unauthorized("Invalid username and password");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier.ToString(), user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(10),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.SecretJwtKey!)),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(tokenCreated);

        return Ok(new
        {
            user,
            token
        });
    }
}
