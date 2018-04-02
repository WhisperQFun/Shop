using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
