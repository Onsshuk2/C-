using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text;

namespace _17_Atributes_Serialization
{
    public class User
    {
        [Range(1000, 9999, ErrorMessage = "ID має бути унікальним значенням в діапазоні 1000 - 9999.")]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login повинен містити лише друковані символи без спец символів.")]
        public string Login { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]{8,}$", ErrorMessage = "Password повинен містити лише друковані символи без спец символів, довжина не менше 8ми символів.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password і ConfirmPassword не співпадають.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Некоректний E-mail.")]
        public string Email { get; set; }

        [CreditCard(ErrorMessage = "Некоректний номер кредитної картки.")]
        public string CreditCard { get; set; }

        [RegularExpression(@"^\+38-0\d{2}-\d{7}$", ErrorMessage = "Phone повинен бути у форматі +38-0**-*******")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Login: {Login}, Email: {Email}, Phone: {Phone}";
        }
    }

    internal class Program
    {
        static Dictionary<int, User> users = new Dictionary<int, User>();
        static string filePath = "users.json";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            LoadFromFile();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Додати користувача");
                Console.WriteLine("2. Відобразити всіх користувачів");
                Console.WriteLine("3. Оновити користувача");
                Console.WriteLine("4. Видалити користувача");
                Console.WriteLine("5. Зберегти дані у файл");
                Console.WriteLine("6. Завантажити дані з файлу");
                Console.WriteLine("7. Вихід");
                Console.Write("Виберіть опцію: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            DisplayUsers();
                            break;
                        case 3:
                            UpdateUser();
                            break;
                        case 4:
                            DeleteUser();
                            break;
                        case 5:
                            SaveToFile();
                            break;
                        case 6:
                            LoadFromFile();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Невірний ввід. Спробуйте ще раз.");
                }
            }
        }

        static void AddUser()
        {
            User user = new User();
            Console.Write("Введіть ID: ");
            user.Id = int.Parse(Console.ReadLine());

            if (users.ContainsKey(user.Id))
            {
                Console.WriteLine("Користувач з таким ID вже існує.");
                return;
            }

            Console.Write("Введіть Login: ");
            user.Login = Console.ReadLine();
            Console.Write("Введіть Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Підтвердіть Password: ");
            user.ConfirmPassword = Console.ReadLine();
            Console.Write("Введіть Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Введіть номер кредитної картки: ");
            user.CreditCard = Console.ReadLine();
            Console.Write("Введіть телефон: ");
            user.Phone = Console.ReadLine();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine("Користувача не додано через помилки валідації.");
            }
            else
            {
                users.Add(user.Id, user);
                Console.WriteLine("Користувача додано.");
            }
        }

        static void DisplayUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Список користувачів порожній.");
            }
            else
            {
                foreach (var user in users.Values)
                {
                    Console.WriteLine(user);
                }
            }
        }

        static void UpdateUser()
        {
            Console.Write("Введіть ID користувача, якого хочете оновити: ");
            int id = int.Parse(Console.ReadLine());

            if (!users.ContainsKey(id))
            {
                Console.WriteLine("Користувача з таким ID не знайдено.");
                return;
            }

            User user = users[id];
            Console.Write("Введіть новий Login: ");
            user.Login = Console.ReadLine();
            Console.Write("Введіть новий Password: ");
            user.Password = Console.ReadLine();
            Console.Write("Підтвердіть новий Password: ");
            user.ConfirmPassword = Console.ReadLine();
            Console.Write("Введіть новий Email: ");
            user.Email = Console.ReadLine();
            Console.Write("Введіть новий номер кредитної картки: ");
            user.CreditCard = Console.ReadLine();
            Console.Write("Введіть новий телефон: ");
            user.Phone = Console.ReadLine();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine("Користувача не оновлено через помилки валідації.");
            }
            else
            {
                users[id] = user;
                Console.WriteLine("Користувача оновлено.");
            }
        }

        static void DeleteUser()
        {
            Console.Write("Введіть ID користувача, якого хочете видалити: ");
            int id = int.Parse(Console.ReadLine());

            if (users.Remove(id))
            {
                Console.WriteLine("Користувача видалено.");
            }
            else
            {
                Console.WriteLine("Користувача з таким ID не знайдено.");
            }
        }

        static void SaveToFile()
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("Дані збережено у файл.");
        }

        static void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<Dictionary<int, User>>(json);
                Console.WriteLine("Дані завантажено з файлу.");
            }
            else
            {
                Console.WriteLine("Файл не знайдено.");
            }
        }
    }
}

