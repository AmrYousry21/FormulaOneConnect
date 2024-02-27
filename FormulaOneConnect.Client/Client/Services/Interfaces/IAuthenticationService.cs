using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;

namespace FormulaOneConnect.Client.Services.Interfaces;

public interface IAuthenticationService
{
    Task<Result> Login(LoginDto loginDto);
    Task Logout();
}