
using System.Collections.Generic;

namespace Simple_Inventory_Management_System
{
    internal class Inventory : IInventory
    {   
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public void AddProduct(Product input)
        {
            if (products.ContainsKey(input.Name))
            {
                products[input.Name].Quantity += input.Quantity;
            }else
            {
                products.Add(input.Name, input);
            }
        }

        public void deleteProduct(string input)
        {
            if(products.ContainsKey(input))
            {
                products.Remove(input);
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }

        public void editProduct(Product input)
        {
            if (products.ContainsKey(input.Name))
            {
                products[input.Name] = input;
            }
        }

        public IEnumerable<Product> ListProducts() => products.Values;


        public Product? searchProduct(string input) => products.ContainsKey(input) ? products[input] : null;

    }
}
