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

namespace AppleRepair.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : BaseWindow
    {
   
        private bool isOperationAdd;
        private string fullName;
        private string phoneNumber;
        private string email;
        private Client currentClient;
        public ClientWindow(bool isOperationAdd = true, Client client = null)
        {
            InitializeComponent();
            DataContext = this;
            IsOperationAdd = isOperationAdd;
            if (client != null)
            {
                currentClient = client;
            }
            if (!IsOperationAdd)
            {
                FullName = currentClient.FullName;
                PhoneNumber = currentClient.PhoneNumber;
                Email = currentClient.Email;
            }

        }
        public string FullName { get { return fullName; } set { fullName = value; OnPropertyChanged(); } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; OnPropertyChanged(); } }
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
        public bool IsOperationAdd { get { return isOperationAdd; } set { isOperationAdd = value; OnPropertyChanged(); } }
       
        private bool Validate()
        {
            if (!string.IsNullOrEmpty(FullName) &&
                !string.IsNullOrEmpty(PhoneNumber) &&
                !string.IsNullOrEmpty(Email))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
                return false;
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {

            if (Validate())
            {
                if (IsOperationAdd)
                {
                    using (var db = new AppleRepairContext())
                    {
                        var client = new Client
                        {
                            FullName = FullName,
                            PhoneNumber = PhoneNumber,
                            Email = Email,
                            IsActive = true
                        };

                        db.Client.Add(client);
                        await db.SaveChangesAsync();
                        MessageBox.Show("Клиент успешно создан!");
                        this.DialogResult = true;
                    }
                }
                else
                {
                    using (var db = new AppleRepairContext())
                    {
                        var client = db.Client.FirstOrDefault(p => p.Id == currentClient.Id);

                        client.FullName = FullName;
                        client.Email = Email;
                        client.PhoneNumber = PhoneNumber;
                        await db.SaveChangesAsync();
                        MessageBox.Show("Клиент успешно обновлён!");
                        this.DialogResult = true;
                    }
                }
            }
        }
    }
}
