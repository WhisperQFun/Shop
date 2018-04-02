using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class RegisterModel
    {
        [Required]
        public string login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public string addres { get; set; }
    }
}
