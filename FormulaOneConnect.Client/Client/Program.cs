using Blazored.LocalStorage;
using FormulaOneConnect.Client;
using FormulaOneConnect.Client.Services;
using FormulaOneConnect.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var configuration = builder.Configuration;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://formulaoneconnect-5428e98fc39c.herokuapp.com/FormulaOneConnect.API") });
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();
