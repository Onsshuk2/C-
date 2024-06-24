using System.Threading.Channels;

namespace _05_StructRefOut_HomeWork
{
    class Worker
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Fathername { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = (value >= 18) && (value <= 60) ? value : throw new Exception("Incorrect value"); }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set { salary = (value > 7000) ? value : throw new Exception("Very low salary, you need to get a new job to survive"); }
        }

        private DateTime dateWork;
        public DateTime DateWork
        {
            get { return dateWork; }
            set { dateWork = (value < DateTime.Now) ? value : throw new Exception("Incorrect dateWork"); }
        }

        static void InputWorkers(Worker[] workers)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker();

                Console.Write("Enter Name: ");
                workers[i].Name = Console.ReadLine();

                Console.Write("Enter Sername: ");
                workers[i].Sername = Console.ReadLine();

                Console.Write("Enter Fathername: ");
                workers[i].Fathername = Console.ReadLine();

                Console.Write("Enter Age: ");
                workers[i].Age = int.Parse(Console.ReadLine());

                Console.Write("Enter Salary: ");
                workers[i].Salary = int.Parse(Console.ReadLine());

                Console.Write("Enter DateWork (yyyy-mm-dd): ");
                workers[i].DateWork = DateTime.Parse(Console.ReadLine());
            }
        }

        static void SortWorkers(Worker[] workers)
        {
            Array.Sort(workers, (x, y) => string.Compare(x.Name, y.Name));
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Sername: {Sername}, Fathername: {Fathername}, Age: {age}, Salary: {salary}, DateWork: {DateWork.ToShortDateString()}");
        }
    }

    class Calculator
    {
        public int number1 { set; get; }
        public int number2 { set; get; }
        public void Addition()
        {
           Console.WriteLine($"Addition:{number1}+{number2}={number1+number2} ");
        }

        public void Subtraction()
        {
            Console.WriteLine($"Addition:{number1}-{number2}={number1-number2} ");
            
        }

        public void Multiplication()
        {
            Console.WriteLine($"Addition:{number1}*{number2}={number1*number2} ");
           
        }
        public void Division()
        {
            if (number2 == 0)
            {
                Console.WriteLine("Division: Division by zero is not allowed.");
            }
            else
            {
                Console.WriteLine($"Division: {number1} / {number2} = {number1 / number2}");
            }
        }
       
    }
    
    internal class Program
    {  
        static void InputWorkers(Worker[] workers)
    {
        for (int i = 0; i < workers.Length; i++)
        {
            workers[i] = new Worker();

            Console.Write("Enter Name: ");
            workers[i].Name = Console.ReadLine();

            Console.Write("Enter Sername: ");
            workers[i].Sername = Console.ReadLine();

            Console.Write("Enter Fathername: ");
            workers[i].Fathername = Console.ReadLine();

            Console.Write("Enter Age: ");
            workers[i].Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Salary: ");
            workers[i].Salary = int.Parse(Console.ReadLine());

            Console.Write("Enter DateWork (yyyy-mm-dd): ");
            workers[i].DateWork = DateTime.Parse(Console.ReadLine());
        }
    }
        static void SortWorkers(Worker[] workers)
       {
        Array.Sort(workers, (x, y) => string.Compare(x.Name, y.Name));
       }

        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            InputWorkers(workers);
            SortWorkers(workers);

            Console.WriteLine("\nWorkers sorted by Name:");
            foreach (var worker in workers)
            {
                worker.Print();
            }
            Calculator c = new Calculator();
            Console.Write("Enter the first number: ");
            c.number1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            c.number2 = int.Parse(Console.ReadLine());
            c.Addition();
            c.Subtraction();
            c.Multiplication();
            c.Division();

        }

        

    }
}
