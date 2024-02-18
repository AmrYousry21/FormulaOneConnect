using FormulaOneConnect.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Data.Models;

[Table("Users")]
public class User : MetaData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public Guid Id { get; set; }

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

    [MaxLength(100)]
    public string? Address { get; set; }

    [MaxLength(50)]
    public string? City { get; set; }

    [StringLength(2)]
    public string? State { get; set; }

    [StringLength(10)]
    public string? Zip { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(200)]
    public string Password { get; set; } = default!;

    [Required]
    public UserRoleEnum UserRole { get; set; }
}
