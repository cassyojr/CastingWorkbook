using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Models;

namespace CastingWorkbook.Repository.Interfaces;

public interface IJobRepository
{
    public Task<IEnumerable<Job>> GetJobsAsync(JobFilter jobFilter);
}
