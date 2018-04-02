using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ItemModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string type_item { get; set; }
        [Required]
        public bool is_avalible { get; set; }
        [Required]
        public float cost { get; set; }
    }
}
