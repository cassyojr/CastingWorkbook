using Asp.Versioning;
using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastingWorkbook.Api.Controllers.Login.V1;

[Authorize]
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;

    public ProjectController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetProjects([FromQuery] ProjectFilter projectViewModel)
    {
        var projects = await _projectRepository.GetProjectsAsync(projectViewModel);
        return projects is null ? NoContent() : Ok(projects);
    }
}
