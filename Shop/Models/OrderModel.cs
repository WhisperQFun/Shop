using Shop.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderModel
    {
       
        public int Id { get; set; }        
        public List<Item> items { get; set; }        
        public string timestamp { get; set; }
        [Required]
        public string description { get; set; }
        public float cost { get; set; }
    }
}
