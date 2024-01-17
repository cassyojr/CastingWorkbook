using CastingWorkbook.Repository.Entities;

namespace CastingWorkbook.Repository.Interfaces;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int userId);
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task<User> GetUserAsync(string userName, string password);
}
