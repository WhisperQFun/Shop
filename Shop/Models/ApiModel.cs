using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ApiModel
    {
        [Required]
        public string site { get; set; }
        [Required]
        public string organisation { get; set; }
    }
}
