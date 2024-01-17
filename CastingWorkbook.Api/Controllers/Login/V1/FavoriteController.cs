using Asp.Versioning;
using CastingWorkbook.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CastingWorkbook.Api.Controllers.Login.V1;

[Authorize]
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteController(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    [HttpGet("projects")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetFavoriteProjects()
    {
        var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier.ToString()).Value;
        var projects = await _favoriteRepository.GetFavoritesAsync(Convert.ToInt32(userId));
        return projects.Any() ? Ok(projects) : NoContent();
    }

    [HttpPost("/add/{projectId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> FavoriteProject([FromRoute] int projectId)
    {
        var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier.ToString()).Value;

        var isFavorited = await _favoriteRepository.FavoriteProjectAsync(Convert.ToInt32(userId), projectId);
        return Ok(isFavorited);
    }

    [HttpPost("/remove/{projectId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UnfavoriteProject([FromRoute] int projectId)
    {
        var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier.ToString()).Value;

        var isFavorited = await _favoriteRepository.UnfavoriteProjectAsync(Convert.ToInt32(userId), projectId);
        return Ok(isFavorited);
    }
}
