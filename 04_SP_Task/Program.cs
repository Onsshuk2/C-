namespace _04_SP_Task
{
    
    internal class Program
    {
        //1
        static void DisplayDateTime()
       {
        Console.WriteLine($"Time: {DateTime.Now.ToLongTimeString()}, Date: {DateTime.Now.ToShortDateString()}");
       }
        //2
        static List<int> FindPrimes(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int number = start; number <= end; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }
            return primes;
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        //3
        static List<int> FindPrimes3(int start, int end)
        {
            List<int> primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime3(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }
        static bool IsPrime3(int number3)
        {
            if (number3 < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number3); i++)
            {
                if (number3 % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
        //4
        static int FindMin(int[] array)
        {
            int min = array[0];
            foreach (int num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
        static int FindMax(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }
        static int CalculateSum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }
        static double CalculateAverage(int[] array)
        {
            int sum = CalculateSum(array);
            return (double)sum / array.Length;
        }

        //5

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // 1
            Task task1 = new Task(DisplayDateTime);
            task1.Start();

            Task task2 = Task.Factory.StartNew(DisplayDateTime);

            Task task3 = Task.Run(() => DisplayDateTime());

            Task.WaitAll(task1, task2, task3);

            Console.WriteLine("End..");

            //2
            Task<List<int>> task = Task.Run(() => FindPrimes(0, 1000));

            task.Wait();

            List<int> primes = task.Result;
            Console.WriteLine("Smple number from 0 to 1000:");
            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }
            //3
            Console.Write("Enter start: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Enter end: ");
            int end = int.Parse(Console.ReadLine());

            Task<List<int>> primesTask = new Task<List<int>>(() => FindPrimes3(start, end));

            primesTask.Start();

            primesTask.Wait();

            int primeCount = primesTask.Result.Count;
            Console.WriteLine($"Number from {start} to {end}: {primeCount}");

            //4
            int[] array = { 5, 2, 9, 4, 7, 6, 1, 3, 8 };

            Task<int> minTask = new Task<int>(() => FindMin(array));
            Task<int> maxTask = new Task<int>(() => FindMax(array));
            Task<int> sumTask = new Task<int>(() => CalculateSum(array));
            Task<double> avgTask = new Task<double>(() => CalculateAverage(array));

            minTask.Start();
            maxTask.Start();
            sumTask.Start();
            avgTask.Start();

            Task.WaitAll(minTask, maxTask, sumTask, avgTask);

            Console.WriteLine($"Min: {minTask.Result}");
            Console.WriteLine($"Max: {maxTask.Result}");
            Console.WriteLine($"Sum: {sumTask.Result}");
            Console.WriteLine($"AVG: {avgTask.Result}");

            //5
            int[] array5 = { 5, 1, 8, 3, 1, 5, 7, 8, 2, 3, 9 };
            Console.WriteLine("Array: ");
            PrintArray(array);

            Task<int[]> taskRemoveDuplicates = Task.Run(() =>
            {
                return array5.Distinct().ToArray(); 
            });

            Task<int[]> taskSortArray = taskRemoveDuplicates.ContinueWith(antecedent =>
            {
                int[] sortedArray = antecedent.Result;
                Array.Sort(sortedArray); 
                return sortedArray;
            });

            Task taskBinarySearch = taskSortArray.ContinueWith(antecedent =>
            {
                int[] sortedArray = antecedent.Result;
                Console.WriteLine("Array without repeat: ");
                PrintArray(sortedArray);

                Console.Write("Enter number by search: ");
                int searchValue = int.Parse(Console.ReadLine());

                int searchIndex = Array.BinarySearch(sortedArray, searchValue);
                if (searchIndex >= 0)
                    Console.WriteLine($"Value {searchValue} search on index {searchIndex}.");
                else
                    Console.WriteLine($"Value {searchValue} not fund.");
            });

           
            taskBinarySearch.Wait();
        }
    }
}
