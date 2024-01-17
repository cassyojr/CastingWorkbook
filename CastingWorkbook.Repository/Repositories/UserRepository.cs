using CastingWorkbook.Repository.Context;
using CastingWorkbook.Repository.Entities;
using CastingWorkbook.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CastingWorkbook.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CastingWorkbookContext _context;

    public UserRepository(CastingWorkbookContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int userId) =>
        await _context.Users.SingleAsync(x => x.Id == userId);

    public async Task<User> GetUserAsync(string userName, string password)
        => await _context.Users.Where(x => x.UserName == userName && x.Password == password).SingleOrDefaultAsync();

    public async Task<IEnumerable<User>> GetUsersAsync() => await _context.Users.ToListAsync();
}
