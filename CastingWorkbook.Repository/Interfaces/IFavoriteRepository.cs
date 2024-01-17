using CastingWorkbook.Repository.Entities;

namespace CastingWorkbook.Repository.Interfaces;

public interface IFavoriteRepository
{
    public Task<bool> FavoriteProjectAsync(int userId, int projectId);
    public Task<bool> UnfavoriteProjectAsync(int userId, int projectId);
    public Task<IEnumerable<Project>> GetFavoritesAsync(int userId);
}
