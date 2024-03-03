using Blazored.LocalStorage;
using FormulaOneConnect.Client.Services.Interfaces;
using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FormulaOneConnect.Client.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public AuthenticationService(AuthenticationStateProvider authenticationStateProvider, HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<Result> Login(LoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("User/Login", loginDto);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) 
        {
            return new Result() 
            {
                Success = false,
                Message = content
            };
        }

        await _localStorageService.SetItemAsync("authToken", content);
        ((AuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(loginDto.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", content);

        return new Result() { Success = true };
    }

    public async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("authToken");
        ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}