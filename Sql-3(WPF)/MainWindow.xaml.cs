using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Data.SqlClient;
using Sql_3_WPF_.Entitis;
namespace Sql_3_WPF_
{
    public partial class MainWindow : Window
    {
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["SportShopDB"].ConnectionString;

            
            LoadClients();
            LoadEmployees();
            LoadSales();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void AddNewSale(Sale sale)
        {
            using (Microsoft.Data.SqlClient.SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string insertQuery = @"INSERT INTO Salles (ProductId, Price, Quantity, SaleDate, EmployeeId, ClientId) 
                                       VALUES (@ProductId, @Price, @Quantity, с @EmployeeId, @ClientId)";

                using (SqlCommand command = new SqlCommand(insertQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@ProductId", sale.ProductId);
                    command.Parameters.AddWithValue("@Price", sale.Price);
                    command.Parameters.AddWithValue("@Quantity", sale.Quantity);
                    command.Parameters.AddWithValue("@SaleDate", sale.SaleDate);
                    command.Parameters.AddWithValue("@EmployeeId", sale.EmployeeId);
                    command.Parameters.AddWithValue("@ClientId", sale.ClientId);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("New sale added successfully!");
            LoadSales(); 
        }


        private void LoadClients()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT Id, FullName FROM Clients";

                using (SqlCommand command = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            //ClientsListBox.ItemsSource = clients; // доданий рядок коду
        }

        private void LoadEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT Id, FullName FROM Employees";

                using (SqlCommand command = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            //EmployeesListBox.ItemsSource = employees; // доданий рядок коду
        }

        private void LoadSales()
        {
            List<Sale> sales = new List<Sale>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string selectQuery = "SELECT Id, ProductId, Price, Quantity, SaleDate, EmployeeId, ClientId FROM Salles";

                using (SqlCommand command = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                Id = reader.GetInt32(0),
                                ProductId = reader.GetInt32(1),
                                Price = reader.GetDecimal(2),
                                Quantity = reader.GetInt32(3),
                                SaleDate = reader.GetDateTime(4),
                                EmployeeId = reader.GetInt32(5),
                                ClientId = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            
            //SalesDataGrid.ItemsSource = sales; // доданий рядок коду
        }


        private void AddSaleButton_Click(object sender, RoutedEventArgs e)
        {
            
            Sale newSale = new Sale
            {
                ProductId = 1, 
                Price = 100.0m, 
                Quantity = 2, 
                SaleDate = DateTime.Now,
                EmployeeId = 1, 
                ClientId = 1 
            };

            AddNewSale(newSale);
        }
    }
}