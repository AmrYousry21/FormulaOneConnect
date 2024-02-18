using FormulaOneConnect.API.Services;
using FormulaOneConnect.API.Services.Interfaces;
using FormulaOneConnect.Data.Repositories.Interfaces;
using FormulaOneConnect.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using FormulaOneConnect.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Add repos to the container
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<FormulaOneConnectContext>(options => options.UseMySQL(configuration.GetConnectionString("FormulaOneConnectConnectionString")!));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"], // Replace with your issuer
            ValidAudience = configuration["JWT:Audience"], // Replace with your audience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]!)) // Replace with your secret key
        };
    });

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("Policy_Name", builder => builder.AllowAnyOrigin());
});

// Configure the HTTP request pipeline.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("Policy_Name");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();