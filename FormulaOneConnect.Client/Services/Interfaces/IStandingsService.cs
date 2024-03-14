using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;

namespace FormulaOneConnect.Client.Services.Interfaces
{
    public interface IStandingsService
    {
        Task<StandingResult> GetDriverStandings(int year);
        Task<StandingResult> GetConstructorsStandings(int year);
        Task<DriverResult> GetDrivers(int year);
        Task<CircutResult> GetTracks(int year);
    }
}
