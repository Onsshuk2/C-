using System.Runtime.CompilerServices;

namespace _12_Extension_Homework
{
    static class StringExtantion
    {
        public static bool Palindrome(this string data)
        {

            string reverse = new string(data.Reverse().ToArray());
            return data.Equals(reverse, StringComparison.OrdinalIgnoreCase);//чутливість до реЇстру 
        }
        public static string Encrypt(this string input, int key)
    {
        char[] buffer = input.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            letter = (char)(letter + key);
            buffer[i] = letter;
        }

        return new string(buffer);
    }
    }
    

    public static class ArrayExtantion
    {
        public static int NumberSymbols(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;

            int count = 0;
            foreach (char c in data)
            {
                if (c == s) count++;
            }
            return count;
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your str: ");
            string str = Console.ReadLine();
            if (str.Palindrome())
            {
                Console.WriteLine("The string is a palindrome.");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome.");
            }
            Console.WriteLine($"Count letter of 'o' : {str.NumberSymbols('o')}"); ;
            Console.WriteLine("Enter your string: ");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter your key: ");
            int key = int.Parse(Console.ReadLine());

            string encryptedString = str.Encrypt(key);
            Console.WriteLine($"Encrypted string: {encryptedString}");

        }
    }
}

