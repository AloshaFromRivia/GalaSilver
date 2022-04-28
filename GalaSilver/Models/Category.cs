using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GalaSilver.Models;

public record Category
{
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = "Нет названия категории")]
    [MaxLength(30)]
    [DisplayName("Название категории")]
    public string? Name { get; set; }
}