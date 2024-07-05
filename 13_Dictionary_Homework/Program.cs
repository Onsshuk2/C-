using _13_Dictionary_Homework;
using System;

namespace _13_Dictionary_Homework
{
    class PhoneBook
    {
        private Dictionary<string, string> contacts;

        public PhoneBook()
        {
            contacts = new Dictionary<string, string>();
        }

        public void AddContact(string name, string phoneNumber)
        {
            if (!contacts.ContainsKey(name))
            {
                contacts.Add(name, phoneNumber);
                Console.WriteLine("You add new contact!");
            }
            else
            {
                Console.WriteLine($"Contact '{name}' already exists.");
            }
        }
        public string SearchContact(string name)
        {
            if (contacts.TryGetValue(name, out string phoneNumber))
            {
                return $"Contact '{name}' found with phone number '{phoneNumber}'.";
            }
            else
            {
                return $"Contact '{name}' not found.";
            }
        }
        public void UpdateContact(string name, string newPhoneNumber)
        {
            if (contacts.ContainsKey(name))
            {
                contacts[name] = newPhoneNumber;
                Console.WriteLine($"Contact '{name}' updated with new phone number '{newPhoneNumber}'.");
            }
            else
            {
                Console.WriteLine($"Contact '{name}' not found.");
            }
        }
        public void DeleteContact(string name)
        {
            if (contacts.Remove(name))
            {
                Console.WriteLine($"Contact '{name}' removed.");
            }
            else
            {
                Console.WriteLine($"Contact '{name}' not found.");
            }
        }
        public void Print()
        {
            foreach (KeyValuePair<string, string> contact in contacts)
            {
                Console.WriteLine(contact.Key + " - " + contact.Value);
            }

        }


    }
    public class WordStatistics
    {
        private Dictionary<string, int> wordCount;

        public WordStatistics()
        {
            wordCount = new Dictionary<string, int>();
        }

        public void ProcessText(string text)
        {
           //цю функцію писала не сама
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = text.ToLower().Split()
                .Select(x => x.Trim(punctuation))
                .Where(x => !string.IsNullOrEmpty(x));

            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }
        }

        public void DisplayStatistics()
        {
            Console.WriteLine("Word\tCount");
            Console.WriteLine("---------------");

            foreach (var item in wordCount)
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)

        {
            PhoneBook phoneBook = new PhoneBook();
            Console.WriteLine("Hello, I'am you new phone book, enter number in menu:");
            Console.WriteLine("----------------MENU----------------");
            while (true)
            {
                Console.WriteLine("""
                    1. Add contact
                    2. SearchContact
                    3. UpdateContact
                    4. DeleteContact
                    5. Print all contact
                    6. Exit
                    Choose an option:
                    """);
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("What contact do you wont to add?");
                        string numberUser = Console.ReadLine();
                        string nameUser = Console.ReadLine();
                        phoneBook.AddContact(numberUser, nameUser);
                        break;
                    case "2":
                        Console.WriteLine("What a number do you wont to Search ?");
                        string numberUserS = Console.ReadLine();
                        phoneBook.SearchContact(numberUserS);
                        break;
                    case "3":
                        Console.WriteLine("What contact do you wont to Update?");
                        string numberUserU = Console.ReadLine();
                        string nameUserU = Console.ReadLine();
                        phoneBook.UpdateContact(numberUserU, nameUserU);
                        break;
                    case "4":
                        Console.WriteLine("What name do you wont to Delete?");
                        string nameUserD = Console.ReadLine();
                        phoneBook.DeleteContact(nameUserD);
                        return;
                    case "5":
                        phoneBook.Print();
                        return;
                    case "6":
                        Console.WriteLine("Exiting program");
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.ReadLine();
                Console.Clear();

            string text = @"Here is the house that Jack built. And this is wheat, which
kept in a dark storeroom in the house he built
jack And this is a cheerful tit bird that often steals
wheat, which is stored in a dark storeroom in the house,
which Jack built.";

            WordStatistics stats = new WordStatistics();
            stats.ProcessText(text);
            stats.DisplayStatistics();





        }
    }
  }
}

