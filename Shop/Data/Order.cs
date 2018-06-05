using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Order
    {
        public int orderId { get; set; }
        public string items { get; set; }
        public string timestamp { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public bool is_active { get; set; }
        public float cost { get; set; }
    }
}
