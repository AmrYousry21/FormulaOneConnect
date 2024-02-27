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
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        //Validate input
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        //Check if email is already in use 
        var userInDb = await _userRepository.GetUserByEmail(registerDto.Email);
        if (userInDb != null)
            return BadRequest("Email is already in use");

        var user = new User
        {
            Email = registerDto.Email,
            Password = registerDto.Password,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            UserRole = UserRoleEnum.Member
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
        if (loginDto.Password != user.Password)
            return BadRequest("Invalid Password");

        // Generate JWT Token
        var token = _authenticationService.GenerateToken(user.Id, user.Email, user.UserRole.ToString()!);

        return Ok(token);
    }
}
