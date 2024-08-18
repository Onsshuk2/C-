using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace APP_C_Sharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        private object textBoxEmail;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            db = new AppContext();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 50;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(5);
            buttonReg.BeginAnimation(Button.WidthProperty, doubleAnimation);
            
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPass.Password.Trim();
            string pass_2 = textBoxPass2.Password.Trim();
            string email = textBoxLogin.Text.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Enter the correct login, it must not exceed 5 digits ";
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
            if (pass != pass_2)
            {
                textBoxPass2.ToolTip = "Enter the correct password ";
                textBoxPass2.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxPass2.ToolTip = "";
                textBoxPass2.Background = Brushes.Transparent;
            }
            

               MessageBox.Show("It's okey");
               User user = new User(login, email, pass);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                db.Users.Add(user);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                db.SaveChanges();

                Window1 win = new Window1();
                win.Show();
                Hide();
            } 
        }

        //private void Button_Window_Click(object sender, RoutedEventArgs e)
        //{
        //    Window1 win = new Window1();
        //    win.Show();
        //    Hide();
        //}
    }
