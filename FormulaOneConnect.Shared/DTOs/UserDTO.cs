using FormulaOneConnect.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Shared.DTOs;

public class UserDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [MinLength(8)]
    [MaxLength(200)]
    public string Password { get; set; } = default!;

    [Required]
    public UserRoleEnum UserRole { get; set; }
}
