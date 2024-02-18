

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FormulaOneConnect.Data.Models;

public class League
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public Guid Id { get; set; }

    [Required] 


    [Required]
    [MaxLength(50)]
    public string LeagueName { get; set; } = default!;

}
