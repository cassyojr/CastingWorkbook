using CastingWorkbook.Repository.Context;
using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CastingWorkbook.Repository.Repositories;

public class JobRepository : IJobRepository
{
    private readonly CastingWorkbookContext _context;

    public JobRepository(CastingWorkbookContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Job>> GetJobsAsync(JobFilter jobFilter)
    {
        var query = _context.Jobs.AsQueryable();

        if (jobFilter != null)
        {
            if (!string.IsNullOrWhiteSpace(jobFilter.SearchTitle))
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{jobFilter.SearchTitle}%"));
            if (!string.IsNullOrWhiteSpace(jobFilter.SearchDescription))
                query = query.Where(x => EF.Functions.Like(x.Description, $"%{jobFilter.SearchDescription}%"));
        }

        return await query.ToListAsync();
    }
}
