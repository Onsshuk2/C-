
namespace _06_SP_ParallelClass
{
    
    internal class Program
    {
       
        
        static void Main(string[] args)
        {
            //1
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть число для обчислення факторіалу: ");
            int number = int.Parse(Console.ReadLine());


            if (number < 0)
            {
                Console.WriteLine("Факторіал для від'ємних чисел не визначено.");
                
               return;
            }
             int factorial = CalculateFactorialParallel(number);
           //2
            Task<int> digitsCountTask = Task.Run(() => CountDigits(number));
            Task<int> digitsSumTask = Task.Run(() => SumDigits(number));

            Task.WaitAll(digitsCountTask, digitsSumTask);

            Console.WriteLine($"Факторіал числа {number} = {factorial}");
            Console.WriteLine($"Кількість цифр у числі: {digitsCountTask.Result}");
            Console.WriteLine($"Сума цифр числа: {digitsSumTask.Result}");
            //3
            Console.Write("Введіть нижню межу діапазону: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Введіть верхню межу діапазону: ");
            int end = int.Parse(Console.ReadLine());

            GenerateMultiplicationTable(start, end);
            //4
            string filePath = "numbers.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 1; i <= 10; i++)
                {
                    writer.WriteLine(i);
                }
            }

            Console.WriteLine($"Файл '{filePath}' створено з числами від 1 до 10.");
            List<int> numbers = new List<int>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (int.TryParse(line, out int number0))
                    {
                        numbers.Add(number0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при зчитуванні файлу: " + ex.Message);
                return;
            }

            List<(int number0, int factorial0)> results = new List<(int, int)>();

            Parallel.ForEach(numbers, number0 =>
            {
                int factorial0 = CalculateFactorial(number0);
                lock (results) 
                {
                    results.Add((number0, factorial0));
                }
            });

            Console.WriteLine("Факторіали чисел:");
            foreach (var result in results)
            {
                Console.WriteLine($"Факторіал числа {result.number0} = {result.factorial0}");
            }
            //5
            string fileWithNumbers = "numbersRandom.txt";
            using (StreamWriter numberWriter = new StreamWriter(fileWithNumbers))
            {
                for (int index = 1; index <= 10; index++)
                {
                    numberWriter.WriteLine(new Random().Next(1, 101));
                }
            }

            Console.WriteLine($"Файл '{fileWithNumbers}' створено з випадковими цілими числами.");

            List<int> integerList = new List<int>();
            try
            {
                string[] fileLines = File.ReadAllLines(fileWithNumbers);
                foreach (var currentLine in fileLines)
                {
                    if (int.TryParse(currentLine, out int parsedNumber))
                    {
                        integerList.Add(parsedNumber);
                    }
                }
            }
            catch (Exception fileException)
            {
                Console.WriteLine("Сталася помилка при зчитуванні файлу: " + fileException.Message);
                return;
            }

            int totalSum = integerList.AsParallel().Sum();
            int maxValue = integerList.AsParallel().Max();
            int minValue = integerList.AsParallel().Min();

            // 4. Виведення результатів
            Console.WriteLine($"Сума чисел: {totalSum}");
            Console.WriteLine($"Максимальне число: {maxValue}");
            Console.WriteLine($"Мінімальне число: {minValue}");
        }
    
        //1
        static int CalculateFactorialParallel(int number)
        {
            int result = 1;

            Parallel.For(1, number + 1, i =>
            {
                lock (typeof(Program))
                {
                    result *= i;
                }
            });

            return result;
        }
        //2
        static int CountDigits(int number)
        {
            return number.ToString().Length;
        }
        static int SumDigits(int number)
        {
            int sum = 0;
            foreach (char digit in number.ToString())
            {
                sum += int.Parse(digit.ToString());
            }
            return sum;
        }
        //3
        static void GenerateMultiplicationTable(int start, int end)
        {
            
            Parallel.For(start, end + 1, i =>
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }
                Console.WriteLine(); 
            });
        }
        //4
        static int CalculateFactorial(int number0)
        {
            int result0 = 1;
            for (int i = 1; i <= number0; i++)
            {
                result0 *= i;
            }
            return result0;
        }
    }
}
