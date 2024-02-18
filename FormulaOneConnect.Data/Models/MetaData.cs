
using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Data.Models;

public class MetaData
{
    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public Guid CreateUserId { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    [Required]
    public Guid UpdateUserId { get; set; }
}
