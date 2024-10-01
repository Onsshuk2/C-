using MusicStore_Library.Entities;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicStore_Library.Entities.Customer;

namespace MusicStore_Library
{
    public class Registration
    {
        public bool RegisterCustomer(Customer customer)
        {
            using (var context = new MusicDB())
            {
                customer.Password = HashPassword(customer.Password, context);
                context.Customers.Add(customer);
                context.SaveChanges();
                return true;
            }
        }

        private string HashPassword(string password, MusicDB context)
        {
            while (true)
            {

                var existingCustomer = context.Customers.FirstOrDefault(c => c.Username == password);
                if (existingCustomer == null)
                {
                    
                    Console.WriteLine("The user has been successfully registered.");
                    return password; 
                }
                else
                {
                    
                    Console.WriteLine($"User with name '{password}' already exists.");
                    Console.Write("Enter a new username: ");
                    password = Console.ReadLine(); 
                }
            }

        }
     public bool LoginCustomer(string username, string password)
        {
            using (var context = new MusicDB())
            {
                while (true)
                {
                    var customer = context.Customers.FirstOrDefault(c => c.Username == username);
                    if (customer != null)
                    {
                        return VerifyPassword(password, customer.Password);
                    }
                    else
                    {
                        Console.WriteLine($"User with name '{username}' does not exist.");
                        Console.Write("Enter a valid username: ");
                        username = Console.ReadLine();
                    }
                }
            }
        }

        private bool VerifyPassword(string password1, string password2)
        {
            
           return password1 == password2;
        }
    }
}
