using FormulaOneConnect.Shared.DTOs;

namespace FormulaOneConnect.Client.Services.Interfaces;

public interface IAuthenticationService
{
    Task<HttpResponseMessage> Login(LoginDto loginDto);
}
