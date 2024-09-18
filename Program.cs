using System.Text;

namespace Sql_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Завдання 1:");
            Task1();

            Console.WriteLine("\nЗавдання 2:");
            Task2();

            Console.WriteLine("\nЗавдання 3:");
            Task3();

            Console.WriteLine("\nЗавдання 4:");
            Task4();

            Console.WriteLine("\nЗавдання 5:");
            Task5();

            Console.WriteLine("\nЗавдання 6:");
            Task6();

            Console.WriteLine("\nЗавдання 7:");
            Task7();
        }

        static void Task1()
        {
            int[] numbers = { -10, 5, 3, -2, 8, -1, 0 };
            var positiveSortedNumbers = numbers
                .Where(n => n > 0)
                .OrderBy(n => n);

            Console.WriteLine("Позитивні числа, відсортовані по зростанню:");
            foreach (var num in positiveSortedNumbers)
            {
                Console.WriteLine(num);
            }
        }

        static void Task2()
        {
            int[] numbers = { 10, 15, 23, 7, 99, -5, 12 };
            var positiveTwoDigitNumbers = numbers
                .Where(n => n > 0 && n >= 10 && n < 100);

            int count = positiveTwoDigitNumbers.Count();
            double average = positiveTwoDigitNumbers.Average();

            Console.WriteLine($"Кількість позитивних двозначних чисел: {count}");
            Console.WriteLine($"Середнє арифметичне: {average}");
        }

        static void Task3()
        {
            int[] years = { 2000, 2001, 2004, 1900, 2008, 2012, 2015 };
            var leapYears = years
                .Where(y => (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0))
                .OrderBy(y => y);

            Console.WriteLine("Високосні роки, відсортовані по зростанню:");
            foreach (var year in leapYears)
            {
                Console.WriteLine(year);
            }
        }

        static void Task4()
        {
            int[] numbers = { 7, 2, 9, 4, 8, 5, 6 };
            var maxEven = numbers
                .Where(n => n % 2 == 0)
                .Max();

            Console.WriteLine($"Максимальне парне число: {maxEven}");
        }

        static void Task5()
        {
            string[] strings = { "Hello", "World", "LINQ", "CSharp" };
            var updatedStrings = strings
                .Select(s => s + "!!!");

            Console.WriteLine("Рядки з трьома знаками оклику в кінці:");
            foreach (var str in updatedStrings)
            {
                Console.WriteLine(str);
            }
        }

        static void Task6()
        {
            string[] strings = { "apple", "banana", "cherry", "date" };
            char searchChar = 'a';
            var stringsWithChar = strings
                .Where(s => s.Contains(searchChar));

            Console.WriteLine($"Рядки, які містять символ '{searchChar}':");
            foreach (var str in stringsWithChar)
            {
                Console.WriteLine(str);
            }
        }

        static void Task7()
        {
            string[] strings = { "cat", "dog", "elephant", "bird", "fish" };
            var groupedByLength = strings
                .GroupBy(s => s.Length)
                .OrderBy(g => g.Key);

            Console.WriteLine("Рядки, згруповані за кількістю символів:");
            foreach (var group in groupedByLength)
            {
                Console.WriteLine($"Довжина {group.Key}:");
                foreach (var str in group)
                {
                    Console.WriteLine($"  {str}");
                }
            }
        }
    }
}
