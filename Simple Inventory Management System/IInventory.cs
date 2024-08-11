namespace Simple_Inventory_Management_System
{
    internal interface IInventory
    {
       public void AddProduct(Product input);
       public void editProduct(Product input);
       public void deleteProduct(string input);
       public Product? searchProduct(string input);
       public IEnumerable<Product> ListProducts();


    }
}
