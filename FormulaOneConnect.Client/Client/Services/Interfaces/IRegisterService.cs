using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;

namespace FormulaOneConnect.Client.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<Result> Register(RegisterDto registerDto);
    }
}
