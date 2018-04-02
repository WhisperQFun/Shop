using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class Item
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type_item { get; set; }
        public bool is_avalible { get; set; }
        public float cost { get; set; }
        public string image { get; set; }
    }
}
