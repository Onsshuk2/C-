using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseLibrary
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            
            _connectionString = ConfigurationManager.ConnectionStrings["SportShops"].ConnectionString;
        }

        // клієнтів
        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, Email FROM Clients";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString()
                            });
                        }
                    }
                }
            }

            return clients;
        }

        // продажів
        public List<Sale> GetSales()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, ProductId, Price  FROM Salles";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                
                            });
                        }
                    }
                }
            }

            return sales;
        }
        public List<Employees> GetEmployees()
        {
            List<Employees> em = new List<Employees>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FullName, Salary, Gender  FROM Employees";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            em.Add(new Employees
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),

                                Salary = Convert.ToInt32(reader["Salary"]),
                                
                            });
                        }
                    }
                }
            }

            return em;
        }

    //    public void DeleteClientOrEmployee(int id, string tableName)
    //    {
    //        using (SqlConnection conn = new SqlConnection(_connectionString))
    //        {
    //            conn.Open();
    //            string query = $"DELETE FROM {tableName} WHERE Id = @Id";
    //            using (SqlCommand cmd = new SqlCommand(query, conn))
    //            {
    //                cmd.Parameters.AddWithValue("@Id", id);
    //                cmd.ExecuteNonQuery();
    //            }
    //        }
    //    }

    //    public void AddSale(Sale sale)
    //    {
    //        using (SqlConnection conn = new SqlConnection(_connectionString))
    //        {
    //            conn.Open();
    //            string query = "INSERT INTO Sales (ProductId, Price, Quantity, EmployeeId, ClientId) VALUES (@ProductId, @Price, @Quantity, @EmployeeId, @ClientId)";
    //            using (SqlCommand cmd = new SqlCommand(query, conn))
    //            {
    //                cmd.Parameters.AddWithValue("@ProductId", sale.ProductId);
    //                cmd.Parameters.AddWithValue("@Price", sale.Price);
    //                cmd.Parameters.AddWithValue("@Quantity", sale.Quantity);
    //                cmd.Parameters.AddWithValue("@EmployeeId", sale.EmployeeId);
    //                cmd.Parameters.AddWithValue("@ClientId", sale.ClientId);
    //                cmd.ExecuteNonQuery();
    //            }
    //        }
    //    }

    //    public string GetTopSeller()
    //    {
    //        using (SqlConnection conn = new SqlConnection(_connectionString))
    //        {
    //            conn.Open();
    //            string query = @"SELECT TOP 1 e.FullName, SUM(s.Price * s.Quantity) AS TotalSales
    //                             FROM Employees e
    //                             JOIN Sales s ON e.Id = s.EmployeeId
    //                             GROUP BY e.FullName
    //                             ORDER BY TotalSales DESC";
    //            using (SqlCommand cmd = new SqlCommand(query, conn))
    //            {
    //                using (SqlDataReader reader = cmd.ExecuteReader())
    //                {
    //                    if (reader.Read())
    //                    {
    //                        return $"{reader["FullName"]}, Загальна сума продаж: {reader["TotalSales"]}";
    //                    }
    //                }
    //            }
    //        }
    //        return null;
    //    }
    }
}

