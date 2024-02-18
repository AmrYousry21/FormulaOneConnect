
using FormulaOneConnect.Data.Models;
using FormulaOneConnect.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneConnect.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FormulaOneConnectContext _ctx;

    public UserRepository(FormulaOneConnectContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AddUser(User user)
    {
        await _ctx.Users.AddAsync(user);
        await _ctx.SaveChangesAsync();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUser(Guid id)
    {
        return await _ctx.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _ctx.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}

