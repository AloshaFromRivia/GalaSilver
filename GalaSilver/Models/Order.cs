using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GalaSilver.Models;

public class Order
{
    [BindNever]
    public int OrderID { get; set; }

    [DisplayName("Имя получателя")]
    [Required(ErrorMessage = "Введите имя")]
    public string Name { get; set; }

    [DisplayName("Адрес доставки")]
    [Required(ErrorMessage = "Введите адрес доставки")]
    public string Line1 { get; set; }

    [DisplayName("Город доставки")]
    [Required(ErrorMessage = "Введите город")]
    public string City { get; set; }
    
    [DisplayName("Почтовый индекс")]
    public string Zip { get; set; }

    [DisplayName("Страна доставки")]
    [Required(ErrorMessage = "Введите страну")]
    public string Country { get; set; }
    
}