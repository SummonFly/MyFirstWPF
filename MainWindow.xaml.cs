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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnRegistration(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = FirstPasswordBox.Password.Trim();
            string passwordConfirm = SecondPasswordBox.Password.Trim();
            string email = EmailBox.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                LoginBox.ToolTip = "Uncorrect";
                LoginBox.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                FirstPasswordBox.ToolTip = "Uncorrect";
                FirstPasswordBox.Background = Brushes.DarkRed;
            }else if (passwordConfirm.Length < 5 || password != passwordConfirm)
            {
                SecondPasswordBox.ToolTip = "Uncorrect";
                SecondPasswordBox.Background = Brushes.DarkRed;
            }else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                EmailBox.ToolTip = "Uncorrect";
                EmailBox.Background = Brushes.DarkRed;
            }else
            {
                MessageBox.Show("Success");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBaseManager.GetManager();
        }
    }
}
