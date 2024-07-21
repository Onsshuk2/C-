using System.Text;
using System.Text.RegularExpressions;

namespace _18_Regex_Homework
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string filePath = "file.txt";
            if (!File.Exists(filePath))
            {
                string testContent = "23,5 12.34 -5 42 88 9,1 100 0 -12";
                File.WriteAllText(filePath, testContent);
                Console.WriteLine("Файл створено з тестовим вмістом.");
            }

            string content = File.ReadAllText(filePath);
            Regex fractionalRegex = new Regex(@"\b\d+(\.\d+|,\d+)\b");
            MatchCollection fractionalMatches = fractionalRegex.Matches(content);
            List<string> fractionalNumbers = new List<string>();

            foreach (Match match in fractionalMatches)
            {
                fractionalNumbers.Add(match.Value);
            }
            Console.WriteLine("Дробові числа:");
            foreach (string number in fractionalNumbers)
            {
                Console.WriteLine(number);
            }
            Regex integerRegex = new Regex(@"\b\d+\b");
            MatchCollection integerMatches = integerRegex.Matches(content);
            List<int> integerNumbers = new List<int>();

            foreach (Match match in integerMatches)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    integerNumbers.Add(number);
                }
            }
            Console.WriteLine("\nЦілі числа:");
            foreach (int number in integerNumbers)
            {
                Console.WriteLine(number);
            }
            var positiveNumbers = integerNumbers.Where(n => n > 0).OrderBy(n => n);

            Console.WriteLine("\nПозитивні числа, відсортовані по зростанню:");
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
            var twoDigitPositives = integerNumbers.Where(n => n >= 10 && n < 100);
            int count = twoDigitPositives.Count();
            double average = twoDigitPositives.Any() ? twoDigitPositives.Average() : 0;
            Console.WriteLine($"\nКількість позитивних двозначних чисел: {count}");
            Console.WriteLine($"Середнє арифметичне позитивних двозначних чисел: {average}");
        }
    }
}

