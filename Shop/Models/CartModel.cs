using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data;

namespace Shop.Models
{
    public class CartModel
    {
        public Cart cart { get; set; }
        public int total_cost { get; set; }
    }
}
