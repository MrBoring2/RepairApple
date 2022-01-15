using AppleRepair.Data;
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

namespace AppleRepair.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        private string login;
        private string password;
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppleRepairContext())
            {
                Employee user = null;
                await Task.Run(() => db.Employee.FirstOrDefault(p => p.Login.Equals(Login) && p.Password.Equals(Password)));
                if (user != null)
                {
                    MessageBox.Show("Вы вошли!");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
