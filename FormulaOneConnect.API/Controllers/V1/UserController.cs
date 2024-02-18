using FormulaOneConnect.API.Services.Interfaces;
using FormulaOneConnect.Data.Enums;
using FormulaOneConnect.Data.Models;
using FormulaOneConnect.Data.Repositories.Interfaces;
using FormulaOneConnect.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneConnect.API.Controllers.V1;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public UserController(IUserRepository userRepository, IAuthenticationService authenticationService)
    {
        _userRepository = userRepository;
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto userInput)
    {
        //Validate input
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //Check if email is already in use 
        var userInDb = await _userRepository.GetUserByEmail(userInput.Email);
        if (userInDb != null)
            return BadRequest("Email is already in use");

        var user = new User
        {
            Email = userInput.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(userInput.Password),
            FirstName = userInput.FirstName,
            LastName = userInput.LastName,
            UserRole = UserRoleEnum.Admin
        };

        await _userRepository.AddUser(user);

        return Ok(new { Message = "Registration Successful" });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // Validate input
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Validate email exists in Users
        var user = await _userRepository.GetUserByEmail(loginDto.Email!);
        if (user == null)
            return BadRequest("Email Not Registered");

        // Check if password is valid 
        if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password) == false)
            return BadRequest("Invalid Password");

        // Generate JWT Token
        var token = _authenticationService.GenerateToken(user.Id, user.Email, user.UserRole.ToString()!);

        return Ok(token);
    }
}
