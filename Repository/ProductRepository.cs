using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace App1.Repository
{
    public class ProductRepository
    {
        private readonly string connectionString = DatabaseHelper.GetConnectionString();


        public IList<Product> GetProduct()
        {
            string query = "SELECT * FROM Product";
            IList<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int no = 1;
                        while (reader.Read())
                        {
                            products.Add(PopulatedData(reader, no));
                            no++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<Product>();
            }

            return products;
        }

        private static Product PopulatedData(SqlDataReader reader, int no)
        {
            return new Product
            {
                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0, 
                Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                Price = reader["Price"] != DBNull.Value ? Convert.ToDouble(reader["Price"]) : 0.0
            };
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await Task.Run(() => GetProduct());
        }
    }
}

