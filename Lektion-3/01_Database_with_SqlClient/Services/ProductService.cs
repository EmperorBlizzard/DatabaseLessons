using _01_Database_with_SqlClient.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _01_Database_with_SqlClient.Services;

internal class ProductService
{
    private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Database\Lessons\Lektion-3\01_Database_with_SqlClient\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30";

    // Create
    public int? Create(Product product)
    {

        try
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("IF NOT EXISTS(SELECT Id FROM Products WHERE Name = @Name) INSERT INTO Products OUTPUT INSERTED.Id VALUES (@Name, @Description, @Price) ELSE SELECT Id FROM Products WHERE Name = @Name", conn);

            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            
            conn.Open();

            var result = (int)cmd.ExecuteScalar();
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }


    
    // Read
    public IEnumerable<Product> GetALL() 
    {
        var products = new List<Product>();

        try
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("SELECT * FROM Products", conn);

            conn.Open();
            using var readr = cmd.ExecuteReader();
            while (readr.Read())
            {
                var product = new Product()
                {
                    Id = readr.GetInt32(0),
                    Name = readr.GetString(1),
                    Description = readr.GetString(2),
                    Price = readr.GetDecimal(3),
                };

                products.Add(product);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return products;
    }

    // Update
    public void Update(Product prduct)
    {
        try
        {
            var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand("" +
                "UPDATE Products SET " +
                "   Name = @Name, " +
                "   Description = @Description, " +
                "   Price = @Price " +
                "WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("id", prduct.Id);
            cmd.Parameters.AddWithValue("name", prduct.Name);
            cmd.Parameters.AddWithValue("Description", prduct.Description);
            cmd.Parameters.AddWithValue("Price", prduct.Price);

            conn.Open();
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }



    // Delete

}
