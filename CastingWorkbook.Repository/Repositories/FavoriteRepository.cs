using CastingWorkbook.Repository.Context;
using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Interfaces;
using CastingWorkbook.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CastingWorkbook.Repository.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly CastingWorkbookContext _context;
    private readonly IUserRepository _userRepository;

    public FavoriteRepository(CastingWorkbookContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<bool> FavoriteProjectAsync(int userId, int projectId)
    {
        var favoriteEntity = await GetFavoriteByProject(projectId);

        if (favoriteEntity is null)
            favoriteEntity = await AddFavoriteAsync(projectId);

        if (favoriteEntity.Users.Any(x => x.Id == userId))
            return false;

        var user = await _userRepository.GetByIdAsync(userId);

        favoriteEntity.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnfavoriteProjectAsync(int userId, int projectId)
    {
        var favoriteEntity = await GetFavoriteByProject(projectId);
        if (favoriteEntity is null) 
            return false;

        if (!favoriteEntity.Users.Any(x => x.Id == userId)) 
            return false;

        var user = await _userRepository.GetByIdAsync(userId);
        favoriteEntity.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<IEnumerable<Project>> GetFavoritesAsync(int userId)
    {
        var favorites = await _context.Favorites.Where(x => x.Users.Any(x => x.Id == userId))
           .ToListAsync();
        var projectIds = favorites.Select(x => x.ProjectId).ToList();
        return await _context.Projects.Include(x => x.Jobs).Where(x => projectIds.Contains(x.Id)).ToListAsync();
    }

    public async Task<Favorite> AddFavoriteAsync(int projectId)
    {
        var favorite = new Favorite
        {
            Date = DateTime.Now,
            Users = new List<User>(),
            ProjectId = projectId
        };

        _context.Favorites.Add(favorite);
        await _context.SaveChangesAsync();

        return favorite;
    }

    private async Task<Favorite?> GetFavoriteByProject(int projectId)
        => await _context.Favorites.Include(x => x.Users).SingleOrDefaultAsync(x => x.ProjectId == projectId);
}
