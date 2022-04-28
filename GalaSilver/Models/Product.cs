using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GalaSilver.Models;

public record Product
{
    [Key]
    [Required]
    public  long Id { get; set; }
    [Required(ErrorMessage = "Нет названия")]
    [MaxLength(40)]
    [DisplayName("Название")]
    public string? Name { get; set; }
    [DisplayName("Описание товара")]
    [MaxLength(255)]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Отсутствует категория товара")]
    [DisplayName("Id категории")]
    [ForeignKey("Category")]
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    [Required(ErrorMessage = "Отсутствует цена")]
    [DisplayName("Цена")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "Укажите наличие товара")]
    [DisplayName("Наличие товара")]
    public Stock Stock { get; set; }
    [BindNever]
    public byte[]? Image { get; set; }
}