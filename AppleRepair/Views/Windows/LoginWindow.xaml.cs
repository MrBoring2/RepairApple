using AppleRepair.Data;
using AppleRepair.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppleRepair.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : BaseWindow
    {
        private bool isBtnEnabled;
        private string login;
        private string password;
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            IsBtnEnabled = true;
        }
        public string Login { get { return login; } set { login = value; OnPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }
        public bool IsBtnEnabled { get { return isBtnEnabled; } set { isBtnEnabled = value; OnPropertyChanged(); } }
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppleRepairContext())
            {
                //foreach (var item in db.PhoneModel)
                //{
                //    foreach (var m in db.Material)
                //    {
                //        var temp = item.ModelName.ToLower().Remove(0, 7);

                //        if (temp.All(Char.IsDigit))
                //        {
                //            if(m.Name.ToLower().Contains($"iphone {temp}") && !m.Name.ToLower().Contains("pro") && !m.Name.ToLower().Contains("pro max") && !m.Name.ToLower().Contains("plus") && !m.Name.ToLower().Contains("max") && !m.Name.ToLower().Contains("mini"))
                //                db.AvailableMaterialsForModel.Add(new AvailableMaterialsForModel { MaterialId = m.Id, ModelId = item.Id });
                //        }
                //        else if (temp.Equals($"3g"))
                //        {
                //            if (m.Name.ToLower().Contains($"iphone {temp}") && !m.Name.ToLower().Contains($"iphone 3gs"))
                //                db.AvailableMaterialsForModel.Add(new AvailableMaterialsForModel { MaterialId = m.Id, ModelId = item.Id });
                //        }

                //        else if(temp.Equals($"x"))
                //        {
                //            if (m.Name.ToLower().Contains($"iphone {temp}") && !m.Name.ToLower().Contains($"iphone xr") && !m.Name.ToLower().Contains($"iphone xs") && !m.Name.ToLower().Contains($"iphone xs max"))
                //                db.AvailableMaterialsForModel.Add(new AvailableMaterialsForModel { MaterialId = m.Id, ModelId = item.Id });
                //        }

                //        else if (temp.Equals("se"))
                //        {
                //            if (m.Name.ToLower().Contains($"iphone {temp}") && !m.Name.ToLower().Contains($"se 2020"))
                //                db.AvailableMaterialsForModel.Add(new AvailableMaterialsForModel { MaterialId = m.Id, ModelId = item.Id });
                //        }

                //        else if (m.Name.ToLower().Contains(temp))
                //        {
                //            db.AvailableMaterialsForModel.Add(new AvailableMaterialsForModel { MaterialId = m.Id, ModelId = item.Id });
                //        }
                //    }

                //}
                //db.SaveChanges();

                IsBtnEnabled = false;
                Employee user = null;
                await Task.Run(() => user = db.Employee.FirstOrDefault(p => p.Login.Equals(Login) && p.Password.Equals(Password)));
                if (user != null)
                {
                    UserService.Instance.SetEmployee(user);
                    var mainWindow = new MainAppWindow();
                    mainWindow.Show();
                    this.Close();
                    MessageBox.Show("Добро пожаловать!");
                }
                else
                {
                    IsBtnEnabled = true;
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
