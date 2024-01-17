using Asp.Versioning;
using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CastingWorkbook.Api.Controllers.Job.V1;

[Authorize]
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class JobController : ControllerBase
{
    private readonly IJobRepository _jobRepository;

    public JobController(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetJobs([FromQuery] JobFilter jobFilter)
    {
        var jobs = await _jobRepository.GetJobsAsync(jobFilter);
        return jobs is null ? NoContent() : Ok(jobs);
    }
}
