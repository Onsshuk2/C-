
using System.Configuration;
using System.Windows;
using DatabaseLibrary;



namespace SQL_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseManager _dbManager;

        public MainWindow()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
        }



        private void ShowClients_Click(object sender, RoutedEventArgs e)
        {
            List<Client> clients = _dbManager.GetClients();
            ClientsListBox.Items.Clear();

            foreach (var client in clients)
            {
                ClientsListBox.Items.Add($"{client.FullName} - Телефон: {client.Phone}");
            }
        }

        private void ShowEm_Click(object sender, RoutedEventArgs e)
        {
            List<Employees> employees = _dbManager.GetEmployees();
            EmployeesListBox.Items.Clear();

            foreach (var employee in employees)
            {
                EmployeesListBox.Items.Add($"{employee.FullName} - Зарплата: {employee.Salary}");
            }
        }

        private void ShowSales_Click(object sender, RoutedEventArgs e)
        {
            List<Sale> sales = _dbManager.GetSales();
            SalesListBox.Items.Clear();

            foreach (var sale in sales)
            {
                SalesListBox.Items.Add($"Продаж: {sale.Id} - Продукт: {sale.ProductId} - Ціна: {sale.Price}");
            }
        }
    }


}