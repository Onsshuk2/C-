using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PD_311_AsyncAwait
{
    public partial class MainWindow : Window
    {
        private string sourceFilePath; 
        private string destinationFolderPath; 
        private CancellationTokenSource cancellationTokenSource; 
        public MainWindow()
        {
            InitializeComponent();
        }

        // вибір файлу
        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                sourceFilePath = dialog.FileName;
                MessageBox.Show($"Selected file: {sourceFilePath}");
            }
        }

        // вибор директорії
        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                destinationFolderPath = dialog.FileName;
                MessageBox.Show($"Selected folder: {destinationFolderPath}");
            }
        }

        // копіювання файлів
        private async void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFilePath) || string.IsNullOrEmpty(destinationFolderPath))
            {
                MessageBox.Show("Please select a source file and a destination folder.");
                return;
            }

            if (!int.TryParse(CopyCountBox.Text, out int copies) || copies <= 0)
            {
                MessageBox.Show("Please enter a valid number of copies.");
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            ProgressBar.IsIndeterminate = false;

            try
            {
                for (int i = 0; i < copies; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        MessageBox.Show("Copying process stopped.");
                        break;
                    }

                    string destinationFile = Path.Combine(destinationFolderPath, $"{Path.GetFileNameWithoutExtension(sourceFilePath)}_Copy{i + 1}{Path.GetExtension(sourceFilePath)}");

                    await Task.Run(() =>
                    {
                        File.Copy(sourceFilePath, destinationFile);
                        Dispatcher.Invoke(() =>
                        {
                            list.Items.Add($"Copied to: {destinationFile}");
                            ProgressBar.Value = ((double)(i + 1) / copies) * 100;
                        });
                    });
                }

                if (!token.IsCancellationRequested)
                {
                    MessageBox.Show("Copying process completed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during copying: {ex.Message}");
            }
        }

        // зупинка копіювання
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void CopyCountBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CopyCountBox.Text == "Copies")
            {
                CopyCountBox.Text = "";
                CopyCountBox.Foreground = Brushes.Black;
            }
        }

        private void CopyCountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CopyCountBox.Text))
            {
                CopyCountBox.Text = "Copies";
                CopyCountBox.Foreground = Brushes.Gray;
            }
        }
    }
}
