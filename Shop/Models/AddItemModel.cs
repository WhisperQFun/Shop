using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class AddItemModel
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
			[Required]
            public string image { get; set; }
    
    }
}
