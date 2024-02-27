using FormulaOneConnect.Data.Models;

namespace FormulaOneConnect.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> GetUser(int id);
    Task<User> GetUserByEmail(string email);
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}