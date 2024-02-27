using Blazored.LocalStorage;
using FormulaOneConnect.Client.Services.Interfaces;
using FormulaOneConnect.Shared.DTOs;
using FormulaOneConnect.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FormulaOneConnect.Client.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }

        public async Task<Result> Register(RegisterDto registerDto)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Register", registerDto);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Result()
                {
                    Success = false,
                    Message = content
                };
            }

            return new Result() { Success = true };
        }
    }
}
