
namespace _03_SP_Thread_Потоки_
{
   
    class FileAnaliz
    {
        public int Words { get; private set; }
        public int Lines { get; private set; }
        public int Punctuation { get; private set; }

        private readonly object lock1 = new object(); 

        public void AddWords(int count)
        {
            lock (lock1)
            {
                Words += count;
            }
        }

        public void AddLines(int count)
        {
            lock (lock1)
            {
                Lines += count;
            }
        }

        public void AddPunctuation(int count)
        {
            lock (lock1)
            {
                Punctuation += count;
            }
        }
    }
    internal class Program
    {
            private static readonly char[] PunctuationMarks = { '.', ',', ';', ':', '–', '—', '‒', '…', '!', '?', '"', '\'', '«', '»', '(', ')', '{', '}', '[', ']', '<', '>', '/' };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string directoryPath = @"C:\Users\onssh\OneDrive\Робочий стіл"; 

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Директорія не знайдена.");
                return;
            }

            var files = Directory.GetFiles(directoryPath, "final.txt");

            if (files.Length == 0)
            {
                Console.WriteLine("Файли не знайдено.");
                return;
            }

            FileAnaliz analysisResult = new FileAnaliz();
            Thread[] threads = new Thread[files.Length];

            
            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                threads[i] = new Thread(() => AnalyzeFile(filePath, analysisResult));
                threads[i].Start();
            }

            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            
            Console.WriteLine($"Загальна кількість слів: {analysisResult.Words}");
            Console.WriteLine($"Загальна кількість рядків: {analysisResult.Lines}");
            Console.WriteLine($"Загальна кількість розділових знаків: {analysisResult.Punctuation}");
        }

       
        static void AnalyzeFile(string filePath, FileAnaliz analysisResult)
        {
            string[] lines = File.ReadAllLines(filePath);

            int wordCount = 0;
            int punctuationCount = 0;

            foreach (var line in lines)
            {
                
                var wordsInLine = line.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                wordCount += wordsInLine.Length;

                
                punctuationCount += line.Count(c => PunctuationMarks.Contains(c));
            }

            
            analysisResult.AddWords(wordCount);
            analysisResult.AddLines(lines.Length);
            analysisResult.AddPunctuation(punctuationCount);

            Console.WriteLine($"Аналіз файлу {Path.GetFileName(filePath)} завершено.");
        }
    }
    
}
