using CastingWorkbook.Repository.Context;
using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Enums;
using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CastingWorkbook.Repository.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly CastingWorkbookContext _context;

    public ProjectRepository(CastingWorkbookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync(ProjectFilter projectFilter)
    {
        var query = _context.Projects.Include(x => x.Jobs).AsQueryable();

        if (projectFilter != null)
        {
            if (projectFilter.ProjectType.HasValue) 
                query = query.Where(x => x.ProjectType == projectFilter.ProjectType.Value);
            if (projectFilter.ProjectUnion != null && projectFilter.ProjectUnion.Any()) 
                query = query.Where(x => projectFilter.ProjectUnion.ToList().Contains((int)x.ProjectUnion));

            if (projectFilter.SortOrder.HasValue)
            {
                switch (projectFilter.SortOrder.Value)
                {
                    case SortOrderEnum.CreationDateAsc:
                        query = query.OrderBy(x => x.CreatedDate);
                        break;
                    case SortOrderEnum.CreationDateDesc:
                        query = query.OrderByDescending(x => x.CreatedDate);
                        break;
                    case SortOrderEnum.ExpirationDateAsc:
                        query = query.OrderBy(x => x.ExpirationDate);
                        break;
                    case SortOrderEnum.ExpirationDateDesc:
                        query = query.OrderBy(x => x.ExpirationDate);
                        break;
                    default:
                        break;
                }
            }
        }

        return await query.ToListAsync();
    }
}
