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
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } 
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } 
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }

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
    public string Password { get; set; }

    [Required]
    public UserRoleEnum UserRole { get; set; }
}
