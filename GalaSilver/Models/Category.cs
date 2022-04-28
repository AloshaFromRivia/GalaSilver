using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GalaSilver.Models;

public record Category
{
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = "Нет названия категории")]
    [MaxLength(30)]
    public string? Name { get; set; }
}