using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GalaSilver.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Требуется почта")]
    [DisplayName("Адрес почты")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Требуется пароль")]
    [DisplayName("Пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}