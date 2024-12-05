using System.Data.SqlClient;

namespace Simple_Inventory_Management_System
{
    internal class Inventory : IInventory
    {
        SqlConnection sqlConnection;
        public Inventory()
        {
            sqlConnection = GetConnection();

        }

        private SqlConnection GetConnection()
        {
            Console.WriteLine("Getting Connection... ");
            string dataSourse = @"(localdb)\wasim";
            string DBName = "Inventory Management";
            string connString = $"Data Source={dataSourse};" +
                $"Initial Catalog={DBName};Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Open Connection... ");
                sqlConnection.Open();
                Console.WriteLine("Connectiion Successful");
                return sqlConnection;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                //End the program
                Environment.Exit(1);
                return null;
            }
        }


        public void AddProduct(Product input)
        {
            var product = searchProduct(input.Name);

            if (product is not null)
            {
                product.Quantity += input.Quantity;
                editProduct(product);
            }
            else
            {
                var qurey = "INSERT INTO Products (Name, Price, Quantity) " +
                            "VALUES (@Name, @Price, @Quantity)";
                using (var sqlCommand = new SqlCommand(qurey, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", input.Name);
                    sqlCommand.Parameters.AddWithValue("@Price", input.Price);
                    sqlCommand.Parameters.AddWithValue("@Quantity", input.Quantity);

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"\nInserted {input.Name}");
                }
            }

        }

        public void deleteProduct(string input)
        {
            var product = searchProduct(input);

            if (product is not null)
            {
                string query = "DELETE FROM Products WHERE Name = @Name";
                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", input);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"\nDeleted {input}");
                }
            }
            else
            {
                Console.WriteLine("\nProduct not found");
            }
        }

        public void editProduct(Product input)
        {
            var product = searchProduct(input.Name);

            if (product is not null)
            {
                string query = "UPDATE Products SET Price = @Price, Quantity = @Quantity WHERE Name = @Name";
                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", input.Name);
                    sqlCommand.Parameters.AddWithValue("@Price", input.Price);
                    sqlCommand.Parameters.AddWithValue("@Quantity", input.Quantity);

                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine($"\nUpdated {input.Name}");
                }
            }
        }

        public IEnumerable<Product> ListProducts()
        {

            string query = "SELECT * FROM Products";
            using (var command = new SqlCommand(query, sqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    var products = new List<Product>();
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Name = reader.GetString(1),
                            Price = reader.GetDouble(2),
                            Quantity = reader.GetInt32(3)
                        };
                        products.Add(product);

                    }
                    return products;
                }
            }

        }


        public Product? searchProduct(string input)
        {
            string query = "SELECT * FROM Products WHERE Name = @Name";
            using (var sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Name", input);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product
                        {
                            Name = reader.GetString(1),
                            Price = reader.GetDouble(2),
                            Quantity = reader.GetInt32(3)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
