using System.Text;

namespace C__масив__енам_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region One dimension array

            //Одновимірний масив
            ////1
            //int[] arr = new int[5] ;
            //arr[0] = 11;
            //arr[1] = 12;
            //arr[2] = 13;
            //arr[3] = 14;
            //arr[4] = 150;
            //Console.WriteLine(arr[0]);
            //Console.WriteLine(arr[1]);
            //Console.WriteLine(arr[2]);
            //Console.WriteLine(arr[3]);
            //Console.WriteLine(arr[4]);

            ////2
            //int[] arr2 = new int[5];
            //for (int i = 0; i < arr2.Length; i++)
            //{ 
            //      arr2[i] = i*2;
            //}

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    Console.Write(arr2[i] +" ");
            //}
            //Console.WriteLine();

            ////3
            //int[] arr3 = new int[5] { 1,2,3,4,5};
            //for (int i = 0; i<arr3.Length; i++)
            //{
            //    Console.Write(arr3[i] + " ");
            //}
            //Console.WriteLine();

            ////4
            //int[] arr4 = new int[] { 10, 20, 30, 40, 50 };
            //for (int i = 0; i < arr4.Length; i++)
            //{
            //    Console.Write(arr4[i] + " ");
            //}
            //Console.WriteLine();

            ////5
            //int[] arr5 = new int[5];
            //for (int i = 0; i < arr5.Length; i++)
            //{
            //    Console.Write(arr5[i] + " ");
            //}
            //Console.WriteLine();
            //arr5.SetValue(33, 2);
            //for (int i = 0; i < arr5.Length; i++)
            //{
            //    Console.Write(arr5[i] + " ");
            //}
            //foreach (int i in arr5)
            //{

            //}
            //Console.WriteLine();
            #endregion


            #region Two dimension array
            //Двовимірні масиви
            ////1
            //int[,] array = new int[3, 3];
            //array[0, 0] = 1;
            //array[0, 1] = 2;
            //array[0, 2] = 3;

            //array[1, 0] = 4;
            //array[1, 1] = 5;
            //array[1, 2] = 6;

            //array[2, 0] = 7;
            //array[2, 1] = 8;
            //array[2, 2] = 9;

            //Console.Write(array[0, 0] + " ");
            //Console.Write(array[0, 1] + " ");
            //Console.Write(array[0, 2] + " ");
            //Console.WriteLine();
            //Console.Write(array[1, 0] + " ");
            //Console.Write(array[1, 1] + " ");
            //Console.Write(array[1, 2] + " ");
            //Console.WriteLine();
            //Console.Write(array[2, 0] + " ");
            //Console.Write(array[2, 1] + " ");
            //Console.Write(array[2, 2] + " ");
            //Console.WriteLine();

            ////2
            //int[,]array2=new int[3,4];
            //Console.WriteLine(array2.Length);
            //for (int i = 0; i < array2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array2.GetLength(1); j++)
            //    {
            //        array2[i, j] = i * j + 1;
            //    }
            //}
            //for (int i = 0; i <= array2.GetUpperBound(0); i++)
            //{
            //    for (int j = 0; j <= array2.GetUpperBound(1); j++)
            //    {
            //        Console.Write(array2[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            ////3
            //int[,] arr4 =
            //{
            //      { 1,2,3},
            //      {4,5,6 },
            //      {7,8,9 }
            //};
            //Console.WriteLine(arr4.Length);
            //Console.WriteLine(arr4);
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write($"{arr4[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}



            #endregion

            //1
            int[] arr2 = new int[5] { 1, 2, 3, 4, 5 };


            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();
            int countP = 0;
            int countN = 0;
            int countU = 0;
            for (int i = 0; i < arr2.Length; i++)
            {

                if (arr2[i] % 2 == 0)
                {
                    countP++;
                }
                if (arr2[i] % 2 != 0)
                {
                    countN++;
                }

            }
            Console.WriteLine($"The number of even: {countP}");
            Console.WriteLine($"The number of not even: {countN}");

            for (int i = 0; i < arr2.Length; i++)
            {
                int repeats = 0;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr2[i] == arr2[j])
                    {
                        repeats++;
                    }
                }
                if (repeats == 1)
                {
                    countU++;
                }
            }

            Console.WriteLine($"The number of unique elements: {countU}");
            Console.WriteLine("______________________________");
            //2
            Console.Write("Enter number: ");
            int sizeUser = int.Parse(Console.ReadLine());
            if (sizeUser < 0)
            {
                Console.Write("Enter a positive number");
            }
            else
            {
                int sizeArrey = sizeUser - 1;
                int[] arr = new int[sizeArrey];
                for (int i = 0; i < arr.Length; i++)

                {
                    arr[i] = i * 2;
                }
                Console.Write("Arrey: ");
                for (int i = 0; i < arr.Length; i++)
                {

                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("______________________________");

            //3
            Console.OutputEncoding = Encoding.UTF8;
            int[] A = new int[5];
            double[,] B = new double[3, 4];
            Random random1 = new Random();

            Console.WriteLine("Введіть 5 чисел для масиву A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"A[{i}] = ");
                int v = int.Parse(Console.ReadLine());
                A[i] = v;
            }

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random1.NextDouble() * 100; 
                }
            }
            Console.WriteLine("\nМасив A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            
            Console.WriteLine("\nМасив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write($"{B[i, j]:F2} ");
                }
                Console.WriteLine();
            }
            double maxElement = double.MinValue;
            double minElement = double.MaxValue;
            double totalSum = 0;
            double totalProduct = 1;

            foreach (int value in A)
            {
                if (value > maxElement) maxElement = value;
                if (value < minElement) minElement = value;
                totalSum += value;
                totalProduct *= value;
            }

            foreach (double value in B)
            {
                if (value > maxElement) maxElement = value;
                if (value < minElement) minElement = value;
                totalSum += value;
                totalProduct *= value;
            }

           int sumEvenA = 0;
            foreach (int value in A)
            {
                if (value % 2 == 0)
                {
                    sumEvenA += value;
                }
            }

           
            double sumOddColsB = 0;
            for (int j = 1; j < B.GetLength(1); j += 2)
            {
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    sumOddColsB += B[i, j];
                }
            }

     
            Console.WriteLine("\nЗагальний максимальний елемент: " + maxElement);
            Console.WriteLine("Загальний мінімальний елемент: " + minElement);
            Console.WriteLine("Загальна сума усіх елементів: " + totalSum);
            Console.WriteLine("Загальний добуток усіх елементів: " + totalProduct);
            Console.WriteLine("Сума парних елементів масиву A: " + sumEvenA);
            Console.WriteLine("Сума елементів непарних стовпців масиву B: " + sumOddColsB);
            Console.WriteLine("______________________________");


            //4
            int[,] array2 = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < array2.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    array2[i, j] = random.Next(-100, 100);
                }
            }

           
            Console.WriteLine("2D Array:");
            for (int i = 0; i < array2.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    Console.Write(array2[i, j] + " ");
                }
                Console.WriteLine();
            }

            
            int rows = array2.GetLength(0);
            int cols = array2.GetLength(1);
            int[] array1 = new int[rows * cols];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array1[index] = array2[i, j];
                    index++;
                }
            }

            
            int max = array1[0];
            int min = array1[0];
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] > max)
                {
                    max = array1[i];
                    maxIndex = i;
                }
                if (array1[i] < min)
                {
                    min = array1[i];
                    minIndex = i;
                }
            }

           
            int sum = 0;

            if (maxIndex > minIndex)
            {
                for (int i = minIndex + 1; i < maxIndex; i++)
                {
                    sum += array1[i];
                }
            }
            else
            {
                for (int i = maxIndex + 1; i < minIndex; i++)
                {
                    sum += array1[i];
                }
            }

            
            Console.WriteLine("Max Number: " + max);
            Console.WriteLine("Min Number: " + min);
            Console.WriteLine("Sum between Max and Min: " + sum);
            Console.WriteLine("______________________________");

            //5
            int[] array = { 10, 7, 12, 4, 8, 5, 9 };

            int minA = array[0];
            int count = 0;

            
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

           
            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] - minA) == 5)
                {
                    count++;
                }
            }

            Console.WriteLine($" the number of elements in the given array that are different from the minimum by 5: {count}");


        }
    }
}
