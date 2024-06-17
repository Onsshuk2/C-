using System;
using System.Collections.Specialized;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _03_String__Enum_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            //string str = "Hello word";
            //string userStr;
            //int position;
            //Console.WriteLine("Enter your string:");
            //userStr = Console.ReadLine();
            //Console.WriteLine("Enter your position:");
            //position = int.Parse(Console.ReadLine());
            //str=str.Insert(position, userStr);
            //Console.WriteLine("Resulting string: " + str);

            //2
            //string userStr1,reverse;
            //Console.WriteLine("Enter your string 1: ");
            //userStr1 = Console.ReadLine();
            //reverse = new string(userStr1.Reverse().ToArray());
            //if (userStr1.CompareTo(reverse)==0)
            //{
            //    Console.WriteLine("Is Palindrom");
            //}
            //else
            //{
            //    Console.WriteLine("This is string don't pa
            //    lindrom. Enter enother string");
            //}

            //3
            //string strLorem = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //int totalChars = strLorem.Length;
            //int lowerCaseCount = 0;
            //int upperCaseCount = 0;

            //foreach (char c in strLorem)
            //{
            //    if (char.IsLower(c))
            //    {
            //        lowerCaseCount++;
            //    }
            //    else if (char.IsUpper(c))
            //    {
            //        upperCaseCount++;
            //    }
            //}

            //double lowerCasePercentage = (double)lowerCaseCount / totalChars * 100;
            //double upperCasePercentage = (double)upperCaseCount / totalChars * 100;

            //Console.WriteLine($"Total characters: {totalChars}");
            //Console.WriteLine($"Lowercase letters: {lowerCaseCount} ({lowerCasePercentage:F2}%)");
            //Console.WriteLine($"Uppercase letters: {upperCaseCount} ({upperCasePercentage:F2}%)");

            //4
            string[] array = { "Ira", "Onishchuk", "Orziv", "school", "pen", "table", "dask" };
            int targetLength = 6; 
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length >= targetLength)
                {
                    if (array[i].Length == 3)
                    {
                        array[i] = new string('$', array[i].Length);
                    }

                    else
                    {
                        array[i] = array[i].Substring(0, array[i].Length - 3) + "$$$";
                    }
                }
            }
            foreach (var word in array)
            {
                Console.WriteLine(word);
            }

            //5
            string strLorem1 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            int number;
            Console.WriteLine("Enter your number: ");
            int num = int.Parse(Console.ReadLine());
            string[] words = strLorem1.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            if (num <= 0 || num > words.Length)
            {
                Console.WriteLine("There is no word at this position in the text.");
            }
            else
            {
                Console.WriteLine("The word at position " + num + " is: " + words[num - 1]);
            }

            //6
            string input = "  Hello   world  this  is  a   test  ";
            Console.WriteLine("Original string:");
            Console.WriteLine($"'{input}'");
            input = input.Trim();
            string[] word1 = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join("*", word1);

            Console.WriteLine("Formatted string:");
            Console.WriteLine($"'{result}'");

            //7
            StringBuilder sb = new StringBuilder();
            string input1;

            Console.WriteLine("Enter words (type a word with a period at the end to finish):");

            do
            {
                input1 = Console.ReadLine().Trim();

                if (!input1.EndsWith("."))
                {
                    sb.Append(input1);
                    sb.Append(", ");
                }
            } while (!input1.EndsWith("."));

            string result1 = sb.ToString().TrimEnd(',', ' '); 
            Console.WriteLine("Result:");
            Console.WriteLine(result1);


        }
    }




   
}
