using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;

namespace FormulaOneConnect.Client.Services.Interfaces
{
    public interface IStandingsService
    {
        Task<StandingResult> GetStandings(int year);
        Task<DriverResult> GetDrivers(int year);
        Task<CircutResult> GetTracks(int year);
    }
}
