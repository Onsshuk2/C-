namespace _05_Exceptions_Classwork
{
   
   
    //2
    class CreditCard
    {
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Fathername { get; set; }

        private string cardNumber;
        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = (value.Length == 16) ? value : throw new Exception("Enter correct number, please"); }
        }

        private int cvc;
        public int CVC
        {
            get { return cvc; }
            set { cvc = (value >= 100 && value <= 999) ? value : throw new Exception("Enter correct CVC number, please"); }
        }

        private DateTime dateEnd;
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = (value > DateTime.Now) ? value : throw new Exception("Incorrect expiry date"); }
        }

        public CreditCard(string name, string sername, string fathername, string cardNumber, int cvc, DateTime dateEnd)
        {
            Name = name;
            Sername = sername;
            Fathername = fathername;
            CardNumber = cardNumber;
            CVC = cvc;
            DateEnd = dateEnd;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Information about user credit card:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Sername: {Sername}");
            Console.WriteLine($"Fathername: {Fathername}");
            Console.WriteLine($"Card Number: {cardNumber}");
            Console.WriteLine($"CVC: {cvc}");
            Console.WriteLine($"Expiry Date: {dateEnd.ToShortDateString()}");
        }
    }

    internal class Program
    {
        

        static void Main(string[] args)
        {
            //1
            Console.WriteLine("Enter string number 0-9: ");
            string num=Console.ReadLine();
            try
            {
                int number = int.Parse(num);
                Console.WriteLine("Your number: " + num);
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR. Enter correct number");
            }

            //2
            try
            {
                CreditCard card = new CreditCard("ira", "onishchuk", "anatoliivna", "1234567812345678", 123, new DateTime(2023, 12, 31));
                card.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //3
            Console.Write("Enter a mathematical expression with multiplication ");
            string input = Console.ReadLine();

            try
            {
                string[] tokens = input.Split('*');
                int result = 1;
                foreach (string token in tokens)
                {
                    int number = int.Parse(token);
                    result *= number;
                }
            Console.WriteLine("Result: " + result);
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR. You entered don't correct symbols");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("The error is not known: " + ex.Message);
            }
        }
    }
}

