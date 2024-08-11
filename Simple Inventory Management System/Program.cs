namespace Simple_Inventory_Management_System
{
    internal class Program
    {
        public static IInventory inventory;
        static void Main(string[] args)
        {
            inventory = new Inventory();

            while (true)
            { 
                Console.WriteLine("\nWelcome to Simple Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Edit Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                if (int.TryParse(choice, out int result)){
                    switch (result)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            EditProduct();
                            break;
                        case 3:
                            DeleteProduct();
                            break;
                        case 4:
                            ViewAllProducts();
                            break;
                        case 5:
                            SearchProduct();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }else{
                    Console.WriteLine("Invalid choice");
                }
                
            }
        }
        static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            var price = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            var quantity = Console.ReadLine();
            inventory.AddProduct(new Product { Name = name, Price = double.Parse(price), Quantity = int.Parse(quantity) });

        }
        static void EditProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            var price = Console.ReadLine();
            Console.Write("Enter Product Quantity: ");
            var quantity = Console.ReadLine();
            inventory.editProduct(new Product { Name = name, Price = double.Parse(price), Quantity = int.Parse(quantity) });
        }
        static void DeleteProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            inventory.deleteProduct(name);
        }
        static void ViewAllProducts()
        {
            Console.WriteLine();
            foreach (var product in inventory.ListProducts())
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }
        static void SearchProduct()
        {
            Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            var product = inventory.searchProduct(name);
            if (product != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Product not found");
            }
        }
    }
}
