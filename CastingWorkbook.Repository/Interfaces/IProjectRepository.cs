using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Models;

namespace CastingWorkbook.Repository.Interfaces;

public interface IProjectRepository
{
    public Task<IEnumerable<Project>> GetProjectsAsync(ProjectFilter projectFilter);
}
