using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace ForbiddenWordsFinder
{
    public partial class MainWindow : Window
    {
        private List<string> selectedFilePaths = new List<string>();
        private FileSearcher fileSearcher;

        public MainWindow()
        {
            InitializeComponent();
            fileSearcher = new FileSearcher("C:\\Users\\onssh\\OneDrive\\Робочий стіл");
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Banned Words File",
                Filter = "Text Files (*.txt)|*.txt",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string bannedWordsContent = File.ReadAllText(openFileDialog.FileName);
                txtBannedWords.Text = bannedWordsContent;
            }
        }

        private void SelectFiles_Click(object sender, RoutedEventArgs e)
        {
            // вибір файлів
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Files to Search",
                Filter = "All Files (*.*)|*.*",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
{
    selectedFilePaths = openFileDialog.FileNames.ToList();
    foreach (string s in selectedFilePaths)
    { 
       txtResults.Text += File.ReadAllText(s);
    }
   
}
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            // Отримання заборонених слів
            List<string> bannedWords = txtBannedWords.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Перевірка на наявність заборонених слів
            if (bannedWords.Count == 0)
            {
                MessageBox.Show("Будь ласка, введіть заборонені слова.");
                return;
            }

            var progressIndicator = new Progress<int>(value => progressBar.Value = value);

            // SearchFiles
            await Task.Run(() => fileSearcher.SearchFiles(selectedFilePaths.ToArray(), bannedWords, progressIndicator));

            MessageBox.Show("Пошук завершено!");
        }
    }

}
