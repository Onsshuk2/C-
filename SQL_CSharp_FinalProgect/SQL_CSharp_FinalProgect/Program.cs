using MusicStore_Library;
using MusicStore_Library.Entities;

namespace SQL_CSharp_FinalProgect
{
    internal class Program
    {
        private RecordService recordService = new RecordService();
        private Registration registrationService = new Registration();
        private Reservations reservationsService = new Reservations();
        private Revision revisionService = new Revision();
        private Sale saleService = new Sale();
        private Search searchService = new Search();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.RunMenu();
        }

        public void RunMenu()
        {
            while (true)
            {
                Console.WriteLine("=== Music Store Menu ===");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Login Customer");
                Console.WriteLine("3. Add Record");
                Console.WriteLine("4. Delete Record");
                Console.WriteLine("5. Update Record");
                Console.WriteLine("6. Reserve Record");
                Console.WriteLine("7. View New Releases");
                Console.WriteLine("8. Search Records");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            RegisterCustomer();
                            break;
                        case 2:
                            LoginCustomer();
                            break;
                        case 3:
                            AddRecord();
                            break;
                        case 4:
                            DeleteRecord();
                            break;
                        case 5:
                            UpdateRecord();
                            break;
                        case 6:
                            ReserveRecord();
                            break;
                        case 7:
                            ViewNewReleases();
                            break;
                        case 8:
                            SearchRecords();
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void RegisterCustomer()
        {
            Console.WriteLine("=== Register Customer ===");
            Customer newCustomer = new Customer();
            Console.Write("Enter username: ");
            newCustomer.Username = Console.ReadLine();
            Console.Write("Enter password: ");
            newCustomer.Password = Console.ReadLine();
            Console.Write("Enter first name: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            newCustomer.LastName = Console.ReadLine();

            bool isRegistered = registrationService.RegisterCustomer(newCustomer);
            Console.WriteLine(isRegistered ? "Registration successful!" : "A user with this name already exists.");
        }

        private void LoginCustomer()
        {
            Console.WriteLine("=== Login Customer ===");
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            bool isLoggedIn = registrationService.LoginCustomer(username, password);
            Console.WriteLine(isLoggedIn ? "Login successful!" : "Invalid username or password.");
        }

        private void AddRecord()
        {
            Console.WriteLine("=== Add Record ===");
            Record newRecord = new Record();
            Console.Write("Enter record name: ");
            newRecord.NameRecord = Console.ReadLine();
            Console.Write("Enter artist first name: ");
            newRecord.Artist = new Artist { FirstName = Console.ReadLine() };
            Console.Write("Enter artist last name: ");
            newRecord.Artist.LastName = Console.ReadLine();
            Console.Write("Enter year: ");
            newRecord.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter genre: ");
            newRecord.Genre = new Genre { Name = Console.ReadLine() };
            Console.Write("Enter price: ");
            newRecord.Price = decimal.Parse(Console.ReadLine());

            recordService.AddRecord(newRecord);
            Console.WriteLine("New record added.");
        }

        private void DeleteRecord()
        {
            Console.WriteLine("=== Delete Record ===");
            Console.Write("Enter record ID to delete: ");
            int recordId = int.Parse(Console.ReadLine());
            recordService.DeleteRecord(recordId);
            Console.WriteLine("Record deleted.");
        }

        private void UpdateRecord()
        {
            Console.WriteLine("=== Update Record ===");
            Record updatedRecord = new Record();
            Console.Write("Enter record ID to update: ");
            updatedRecord.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter new record name: ");
            updatedRecord.NameRecord = Console.ReadLine();
            Console.Write("Enter artist first name: ");
            updatedRecord.Artist = new Artist { FirstName = Console.ReadLine() };
            Console.Write("Enter artist last name: ");
            updatedRecord.Artist.LastName = Console.ReadLine();
            Console.Write("Enter year: ");
            updatedRecord.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter genre: ");
            updatedRecord.Genre = new Genre { Name = Console.ReadLine() };
            Console.Write("Enter price: ");
            updatedRecord.Price = decimal.Parse(Console.ReadLine());

            recordService.UpdateRecord(updatedRecord);
            Console.WriteLine("Record updated.");
        }

        private void ReserveRecord()
        {
            Console.WriteLine("=== Reserve Record ===");
            Console.Write("Enter record ID to reserve: ");
            int recordId = int.Parse(Console.ReadLine());
            Console.Write("Enter customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            reservationsService.ReserveRecordForCustomer(recordId, customerId);
            Console.WriteLine("Record reserved.");
        }

        private void ViewNewReleases()
        {
            Console.WriteLine("=== New Releases ===");
            List<Record> newReleases = revisionService.GetNewReleases();
            foreach (var record in newReleases)
            {
                Console.WriteLine($"{record.NameRecord} ({record.Year})");
            }
        }

        private void SearchRecords()
        {
            Console.WriteLine("=== Search Records ===");
            Console.Write("Enter search title: ");
            string title = Console.ReadLine();
            List<Record> foundRecords = searchService.SearchRecordsByTitle(title);
            foreach (var record in foundRecords)
            {
                Console.WriteLine($"Name: {record.NameRecord}, Artist: {record.Artist.FirstName} {record.Artist.LastName}");
            }
        }
    }
}
