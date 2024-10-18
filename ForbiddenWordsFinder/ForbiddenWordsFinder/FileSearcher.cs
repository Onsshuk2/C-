using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForbiddenWordsFinder
{
    public class FileSearcher
    {
        public string DestinationPath { get; }

        public FileSearcher(string destinationPath)
        {
            DestinationPath = destinationPath;
        }

        public void SearchFiles(string[] filePaths, List<string> bannedWords, IProgress<int> progress)
        {
            if (filePaths.Length == 0)
            {
                throw new ArgumentException("Немає файлів для пошуку.");
            }

            int totalFiles = filePaths.Length;
            var report = new List<string>();
            var bannedWordsCount = new Dictionary<string, int>();

            for (int i = 0; i < totalFiles; i++)
            {
                string filePath = filePaths[i];

                if (!File.Exists(filePath))
                {
                    progress.Report((i + 1) * 100 / totalFiles);
                    continue;
                }

                string content = File.ReadAllText(filePath);
                int replacements = 0;

                foreach (var bannedWord in bannedWords)
                {
                    int count = content.Split(new[] { bannedWord }, StringSplitOptions.None).Length - 1;

                    if (count > 0)
                    {
                        replacements += count;
                        if (bannedWordsCount.ContainsKey(bannedWord))
                            bannedWordsCount[bannedWord] += count;
                        else
                            bannedWordsCount[bannedWord] = count;

                        // Заміна заборонених слів на зірочки
                        content = content.Replace(bannedWord, new string('*', 7));
                    }
                }

                // Запис модифікованого файлу
                string modifiedFileName = Path.GetFileName(filePath);
                string modifiedFilePath = Path.Combine(DestinationPath, "new file" + modifiedFileName);
                File.WriteAllText(modifiedFilePath, content);

                report.Add($"File: {filePath}, Replacements: {replacements}");

                progress.Report((i + 1) * 100 / totalFiles);
            }

            // Запис звіту
            string reportFilePath = Path.Combine(DestinationPath, "report.txt");
            File.WriteAllLines(reportFilePath, report);

           
            var topBannedWords = bannedWordsCount.OrderByDescending(kvp => kvp.Value).Take(3);
            using (StreamWriter sw = new StreamWriter(reportFilePath, true))
            {
                sw.WriteLine("\nTop 3 Banned Words:");
                foreach (var item in topBannedWords)
                {
                    sw.WriteLine($"{item.Key}: {item.Value} times");
                }
            }
        }
    }
}
