namespace FormulaOneConnect.API.Services.Interfaces;

public interface IAuthenticationService
{
    string GenerateToken(Guid userId, string email, string userRole);
}
