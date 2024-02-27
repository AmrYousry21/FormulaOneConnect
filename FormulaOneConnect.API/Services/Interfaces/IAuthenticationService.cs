namespace FormulaOneConnect.API.Services.Interfaces;

public interface IAuthenticationService
{
    string GenerateToken(int userId, string email, string userRole);
}
