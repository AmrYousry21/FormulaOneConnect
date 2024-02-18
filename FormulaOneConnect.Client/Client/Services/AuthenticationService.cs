using FormulaOneConnect.Client.Services.Interfaces;
using FormulaOneConnect.Shared.DTOs;
using System.Net.Http.Json;

namespace FormulaOneConnect.Client.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> Login(LoginDto loginDto)
    {
        return await _httpClient.PostAsJsonAsync("/user/Login", loginDto);
    }
}