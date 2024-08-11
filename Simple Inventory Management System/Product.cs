using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Inventory_Management_System
{
    public record Product
    {
        private string _name;
        private double _price;
        private int _quantity;
        
        public string Name { get => _name; set=> _name =value; }
        public double Price { get => _price; set { _price = value < 0 ? 0 : value; } }
        public int Quantity { get => _quantity; set { _quantity = value < 0 ? 0 : value; } }

    }
}
