
using System.IO;
using System.Net;

using System.Windows;


namespace EmailSender_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> activeDownloads = new List<string>();
        private WebClient webClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            string url = UrlTextBox.Text;
            string savePath = SavePathTextBox.Text;
            int threadCount = int.TryParse(ThreadCountTextBox.Text, out var count) ? count : 4;
            string tags = TagsTextBox.Text;

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(savePath))
            {
                MessageBox.Show("Введіть URL та шлях для збереження.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                webClient = new WebClient();
                string fileName = Path.GetFileName(url);
                string fullPath = Path.Combine(savePath, fileName);

                webClient.DownloadFileCompleted += (s, ev) =>
                {
                    if (ev.Error != null)
                    {
                        DownloadsListBox.Items.Add($"Помилка завантаження: {url}");
                    }
                    else
                    {
                        DownloadsListBox.Items.Add($"Завантажено: {fullPath}");
                        activeDownloads.Remove(url);
                    }
                };

                DownloadsListBox.Items.Add($"Запущено: {url}");
                activeDownloads.Add(url);
                await webClient.DownloadFileTaskAsync(new Uri(url), fullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функція призупинення ще не реалізована.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            webClient?.CancelAsync();
            MessageBox.Show("Завантаження зупинено.", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DownloadsListBox.Items.Count > 0)
            {
                // Отримуємо останній елемент
                var lastItem = DownloadsListBox.Items[DownloadsListBox.Items.Count - 1];

                // Видаляємо останній елемент зі списку
                DownloadsListBox.Items.Remove(lastItem);

                // Якщо ви хочете видалити URL з activeDownloads
                string lastUrl = lastItem.ToString(); // Передбачаємо, що ви зберігали URL у вигляді рядка
                activeDownloads.Remove(lastUrl);

                MessageBox.Show($"Останнє завантаження видалено: {lastUrl}", "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Немає завантажень для видалення.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
}
