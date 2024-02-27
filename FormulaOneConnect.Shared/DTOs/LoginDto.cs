using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Shared.DTOs;

public class LoginDto
{
    [Required]
    [MaxLength(30, ErrorMessage = "Email must be at most 30 characters")]
    public string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Pasword must be at least 8 characters")]
    [MaxLength(16, ErrorMessage = "Pasword must be at most 16 characters")]
    public string Password { get; set; }
}
