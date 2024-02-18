using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Shared.DTOs;

public class RegisterDto
{
    [Required]
    [MinLength(1)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(1)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(30)]
    public string Email { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(30)]
    public string Password { get; set; }
}
