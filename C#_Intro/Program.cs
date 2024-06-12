using System.Text;

namespace C__Intro
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Ex1
            Console.WriteLine("\nIt's  easy to forgiveness for being wrong;\n being right is what gets you into real.\n Bjarne Stroustrun");

            //Ex2
            int num1, num2, num3, num4, num5, num6;
            Console.Write("Enter 1 number: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter 2 number: ");
            num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter 3 number: ");
            num3 = int.Parse(Console.ReadLine());

            Console.Write("Enter 4 number: ");
            num4 = int.Parse(Console.ReadLine());

            Console.Write("Enter 5 number: ");
            num5 = int.Parse(Console.ReadLine());

            Console.Write("Enter 5 number: ");
            num6 = int.Parse(Console.ReadLine());

            int sum = num1 + num2 + num3 + num4 + num5 + num6;
            int product = num1 * num2 * num3 * num4 * num5 * num6;
            int max = num1;
            int min = num1;

            if (num2 > max)
            {
                max = num2;
            }
            if (num3 > max)
            {
                max = num3;
            }
            if (num4 > max)
            {
                max = num4;
            }
            if (num5 > max)
            {
                max = num5;
            }
            if (num6 > max)
            {
                max = num6;
            }

            if (num2 < min)
            {
                min = num2;
            }
            if (num3 < min)
            {
                min = num3;
            }
            if (num4 < min)
            {
                min = num4;
            }
            if (num5 < min)
            {
                min = num5;
            }
            if (num6 < min)
            {
                min = num6;
            }

            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Product: " + product);


            //Ex3
            Console.Write("Enter a six-digit number: ");
            int number = int.Parse(Console.ReadLine());

            int reversedNumber = 0;
            int temp = number;

            for (int i = 0; i < 6; i++)
            {
                int digit = temp % 10;
                reversedNumber = reversedNumber * 10 + digit;
                temp = temp / 10;
            }

            Console.WriteLine("Reversed number: " + reversedNumber);

            //Ex4
            Console.Write("Enter begin of the range: ");
            int begin = int.Parse(Console.ReadLine());

            Console.Write("Enter  end of the range: ");
            int end = int.Parse(Console.ReadLine());


            int a = 0, b = 1;

            Console.WriteLine($"Fibonacci numbers in the range {begin} to {end}:");


            while (a <= end)
            {
                if (a >= begin)
                {
                    Console.Write(a + " ");
                }

                int next = a + b;
                a = b;
                b = next;
            }

            Console.WriteLine();

            //Ex5
            Console.Write("Enter A: ");
            int A = int.Parse(Console.ReadLine());

            Console.Write("Enter B: ");
            int B = int.Parse(Console.ReadLine());

            for (int i = A; i <= B; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            //Ex6
           
            Console.Write("Enter the length of the line: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Enter char: ");
            string charUser = Console.ReadLine();
            //Console.WriteLine(); 

           Console.Write("Enter the direction of the line (h for horizontal, v for vertical): ");
            string direction = Console.ReadLine();
            Console.WriteLine(); 

            if (direction == "h")
            {
                
                for (int i = 0; i < length; i++)
                {
                    Console.Write(charUser);
                }
                Console.WriteLine();
            }
            else if (direction == "v")
            {
                
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(charUser);
                }
            }
            else
            { Console.WriteLine("Error: Unknown direction.");}
                
            }
    }
}
