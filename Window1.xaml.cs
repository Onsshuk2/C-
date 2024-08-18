using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APP_C_Sharp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public object Context { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPass.Password.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Enter the correct password, it must not exceed 5 digits ";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }

            if (pass.Length < 5)
            {
                textBoxPass.ToolTip = "Enter the correct password, it must not exceed 5 digits ";
                textBoxPass.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxPass.ToolTip = "";
                textBoxPass.Background = Brushes.Transparent;
            }
            User autUser = null;
            using (AppContext context = new AppContext())
            {
                //autUser = Context.users.Where(b => b.login == login && b.pass == pass).firstordefault();
            }
            if (autUser != null) { 
            MessageBox.Show("It's okey");
                //UserWindow userWindow= new UserWindow();
                //userWindow.Show();
                Hide();
        }
            else
                MessageBox.Show("Enter corect login or password");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //UserWindow userW = new UserWindow();
            //userW.Show();
            Hide();                                                                                                             
        }
    }
}
