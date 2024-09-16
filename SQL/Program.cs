using System;
using System.Data.SqlClient;

namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-LCTPOKA\SQLEXPRESS;Initial Catalog=SportShops;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            Console.WriteLine("Connected successfully");

            // Відображення всіх клієнтів
            string queryClients = "SELECT Id, FullName, Email, Phone, Gender, PercentSale, Subscribe FROM Clients";
            SqlCommand commandClients = new SqlCommand(queryClients, sqlConnection);
            SqlDataReader readerClients = commandClients.ExecuteReader();

            Console.WriteLine("List of clients:");
            while (readerClients.Read())
            {
                int id = readerClients.GetInt32(0);
                string fullName = readerClients.GetString(1);
                string email = readerClients.GetString(2);
                string phone = readerClients.GetString(3);
                string gender = readerClients.GetString(4);
                int percentSale = readerClients.GetInt32(5);
                bool subscribe = readerClients.GetBoolean(6);

                Console.WriteLine($"ID: {id}, Name: {fullName}, Email: {email}, Phone: {phone}, Gender: {gender}, Percent Sale: {percentSale}, Subscribed: {subscribe}");
            }
            readerClients.Close();

            // Відображення всіх продавців
            string queryEmployees = "SELECT Id, FullName, Position, Phone, HireDate FROM Employees";
            SqlCommand commandEmployees = new SqlCommand(queryEmployees, sqlConnection);
            SqlDataReader readerEmployees = commandEmployees.ExecuteReader();

            Console.WriteLine("List of employees:");
            while (readerEmployees.Read())
            {
                int id = readerEmployees.GetInt32(0);
                string fullName = readerEmployees.GetString(1);
                string position = readerEmployees.GetString(2);
                string phone = readerEmployees.GetString(3);
                DateTime hireDate = readerEmployees.GetDateTime(4);

                Console.WriteLine($"ID: {id}, Name: {fullName}, Position: {position}, Phone: {phone}, Hire Date: {hireDate.ToShortDateString()}");
            }
            readerEmployees.Close();

            // Відображення продаж певного продавця
            string employeeFullName = "John Doe"; // Ім'я та прізвище продавця
            string querySalesByEmployee = @"SELECT S.Id, S.ProductId, S.Price, S.Quantity, S.SaleDate 
                                            FROM Salles AS S
                                            INNER JOIN Employees AS E ON S.EmployeeId = E.Id
                                            WHERE E.FullName = @FullName";

            SqlCommand commandSalesByEmployee = new SqlCommand(querySalesByEmployee, sqlConnection);
            commandSalesByEmployee.Parameters.AddWithValue("@FullName", employeeFullName);
            SqlDataReader readerSalesByEmployee = commandSalesByEmployee.ExecuteReader();

            Console.WriteLine($"Sales by employee: {employeeFullName}");
            while (readerSalesByEmployee.Read())
            {
                int saleId = readerSalesByEmployee.GetInt32(0);
                int productId = readerSalesByEmployee.GetInt32(1);
                decimal price = readerSalesByEmployee.GetDecimal(2);
                int quantity = readerSalesByEmployee.GetInt32(3);
                DateTime saleDate = readerSalesByEmployee.GetDateTime(4);

                Console.WriteLine($"Sale ID: {saleId}, Product ID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
            readerSalesByEmployee.Close();

            // Відображення продаж на суму більше певної
            decimal amount = 500.0m; // Сума, більше якої необхідно відображати продажі
            string querySalesAboveAmount = "SELECT Id, ProductId, Price, Quantity, SaleDate FROM Salles WHERE Price * Quantity > @Amount";
            SqlCommand commandSalesAboveAmount = new SqlCommand(querySalesAboveAmount, sqlConnection);
            commandSalesAboveAmount.Parameters.AddWithValue("@Amount", amount);
            SqlDataReader readerSalesAboveAmount = commandSalesAboveAmount.ExecuteReader();

            Console.WriteLine($"Sales with total amount greater than {amount}:");
            while (readerSalesAboveAmount.Read())
            {
                int saleId = readerSalesAboveAmount.GetInt32(0);
                int productId = readerSalesAboveAmount.GetInt32(1);
                decimal price = readerSalesAboveAmount.GetDecimal(2);
                int quantity = readerSalesAboveAmount.GetInt32(3);
                DateTime saleDate = readerSalesAboveAmount.GetDateTime(4);

                Console.WriteLine($"Sale ID: {saleId}, Product ID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
            readerSalesAboveAmount.Close();

            // Відображення найдорожчої та найдешевшої покупки певного клієнта
            string clientFullName = "Jane Doe"; // Ім'я та прізвище клієнта
            // Найдорожча покупка
            string queryMaxPurchase = @"SELECT TOP 1 S.Id, S.ProductId, S.Price, S.Quantity, S.SaleDate
                                        FROM Salles AS S
                                        INNER JOIN Clients AS C ON S.ClientId = C.Id
                                        WHERE C.FullName = @FullName
                                        ORDER BY S.Price * S.Quantity DESC";
            SqlCommand commandMaxPurchase = new SqlCommand(queryMaxPurchase, sqlConnection);
            commandMaxPurchase.Parameters.AddWithValue("@FullName", clientFullName);
            SqlDataReader readerMaxPurchase = commandMaxPurchase.ExecuteReader();

            if (readerMaxPurchase.Read())
            {
                Console.WriteLine("Most expensive purchase:");
                int saleId = readerMaxPurchase.GetInt32(0);
                int productId = readerMaxPurchase.GetInt32(1);
                decimal price = readerMaxPurchase.GetDecimal(2);
                int quantity = readerMaxPurchase.GetInt32(3);
                DateTime saleDate = readerMaxPurchase.GetDateTime(4);

                Console.WriteLine($"Sale ID: {saleId}, Product ID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
            readerMaxPurchase.Close();

            // Найдешевша покупка
            string queryMinPurchase = @"SELECT TOP 1 S.Id, S.ProductId, S.Price, S.Quantity, S.SaleDate
                                        FROM Salles AS S
                                        INNER JOIN Clients AS C ON S.ClientId = C.Id
                                        WHERE C.FullName = @FullName
                                        ORDER BY S.Price * S.Quantity ASC";
            SqlCommand commandMinPurchase = new SqlCommand(queryMinPurchase, sqlConnection);
            commandMinPurchase.Parameters.AddWithValue("@FullName", clientFullName);
            SqlDataReader readerMinPurchase = commandMinPurchase.ExecuteReader();

            if (readerMinPurchase.Read())
            {
                Console.WriteLine("Cheapest purchase:");
                int saleId = readerMinPurchase.GetInt32(0);
                int productId = readerMinPurchase.GetInt32(1);
                decimal price = readerMinPurchase.GetDecimal(2);
                int quantity = readerMinPurchase.GetInt32(3);
                DateTime saleDate = readerMinPurchase.GetDateTime(4);

                Console.WriteLine($"Sale ID: {saleId}, Product ID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
            readerMinPurchase.Close();

            // Відображення найпершої продажі певного продавця
            string queryFirstSale = @"SELECT TOP 1 S.Id, S.ProductId, S.Price, S.Quantity, S.SaleDate 
                                      FROM Salles AS S
                                      INNER JOIN Employees AS E ON S.EmployeeId = E.Id
                                      WHERE E.FullName = @FullName
                                      ORDER BY S.SaleDate ASC";

            SqlCommand commandFirstSale = new SqlCommand(queryFirstSale, sqlConnection);
            commandFirstSale.Parameters.AddWithValue("@FullName", employeeFullName);
            SqlDataReader readerFirstSale = commandFirstSale.ExecuteReader();

            if (readerFirstSale.Read())
            {
                int saleId = readerFirstSale.GetInt32(0);
                int productId = readerFirstSale.GetInt32(1);
                decimal price = readerFirstSale.GetDecimal(2);
                int quantity = readerFirstSale.GetInt32(3);
                DateTime saleDate = readerFirstSale.GetDateTime(4);

                Console.WriteLine($"First sale of {employeeFullName}:");
                Console.WriteLine($"Sale ID: {saleId}, Product ID: {productId}, Price: {price}, Quantity: {quantity}, Date: {saleDate}");
            }
            readerFirstSale.Close();

            sqlConnection.Close();
        }
    }
}

