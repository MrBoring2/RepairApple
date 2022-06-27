using AppleRepair.Data;
using AppleRepair.Services;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : BaseWindow
    {
        private bool isEnabled;
        private Visibility visibility;
        private string description;
        private PhoneModel selectedModel;
        private string selectedService;
        private string selectedServiceInList;
        private Client selectedClient;
        private DateTime date;
        private DateTime time;
        private ObservableCollection<string> selectedServices;
        public OrderWindow(bool isForShown, Order order = null)
        {

            InitializeComponent();

            DataContext = this;
            SelectedServices = new ObservableCollection<string>();
            Date = DateTime.Now.ToLocalTime();
            Time = DateTime.Now.ToLocalTime();
            LoadModels();

            LoadServices();
            if (isForShown)
            {
                IsVisibility = Visibility.Collapsed;
                IsElEnabled = false;
                using (var db = new AppleRepairContext())
                {
                    db.Order.Attach(order);
                    SelectedClient = order.Client;
                    Date = order.EndDate;
                    Time = order.EndDate;
                    Description = order.Decription;
                    foreach (var item in order.Service)
                    {

                        SelectedServices.Add(item.Name);
                    }
                }

            }
            else
            {
                IsElEnabled = true;
                IsVisibility = Visibility.Visible;
            }
        }
        public Visibility IsVisibility { get => visibility; set { visibility = value; OnPropertyChanged(); } }
        public bool IsElEnabled { get => isEnabled; set { isEnabled = value; OnPropertyChanged(); } }

        public string Description { get { return description; } set { description = value; OnPropertyChanged(); } }
        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged(); } }
        public DateTime Time { get { return time; } set { time = value; OnPropertyChanged(); } }
        public Client SelectedClient { get { return selectedClient; } set { selectedClient = value; OnPropertyChanged(); } }
        public List<string> Services { get; set; }
        public List<PhoneModel> Models { get; set; }
        public ObservableCollection<string> SelectedServices { get => selectedServices; set { selectedServices = value; OnPropertyChanged(); } }
        public string SelectedService
        {
            get => selectedService;
            set
            {
                selectedService = value;
                if (SelectedServices.FirstOrDefault(p => p.Equals(SelectedService)) == null)
                    SelectedServices.Add(SelectedService);
                else
                {
                    MessageBox.Show("Данная модель уже есть в списке!");
                }
                OnPropertyChanged();
            }
        }
        public string SelectedServiceInList { get => selectedServiceInList; set { selectedServiceInList = value; OnPropertyChanged(); } }
        public PhoneModel SelectedModel { get => selectedModel; set { selectedModel = value; OnPropertyChanged(); } }
        private void LoadModels()
        {
            using (var db = new AppleRepairContext())
            {
                Models = db.PhoneModel.Include("Color").OrderBy(p => p.Color.Name).ToList();
                SelectedModel = Models.FirstOrDefault();
            }
        }
        private void LoadServices()
        {
            using (var db = new AppleRepairContext())
            {
                Services = new List<string>();
                var services = db.Service;
                foreach (var item in services)
                {
                    Services.Add(item.Name);
                }
            }
        }

        private bool Validate()
        {

            if (!string.IsNullOrEmpty(Description)
                && SelectedServices.Count > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно либо список моделей пуст!");
                return false;
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (var db = new AppleRepairContext())
                {
                    if (db.Client.Find(SelectedClient.Id).IsActive == false)
                    {
                        MessageBox.Show("Клиент не активен!");
                    }
                    else
                    {
                        var order = new Order
                        {
                            StartDate = DateTime.Now.ToLocalTime(),
                            EmployeeId = UserService.Instance.CurrentUser.Id,
                            ClientId = SelectedClient.Id,
                            EndDate = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hour, Time.Minute, Time.Second),
                            Decription = Description,

                            PhoneModelId = SelectedModel.Id,
                            Status = "В процессе выполнения",
                        };
                        var services = db.Service.Where(p => SelectedServices.Contains(p.Name)).ToList();

                        foreach (var item in services)
                        {
                            order.Service.Add(db.Service.FirstOrDefault(p => p.Name.Equals(item.Name)));
                        }
                        order.Price = services.Sum(p => p.Price);
                        db.Order.Add(order);

                        if (order.EndDate >= DateTime.Now.AddDays(1))
                        {
                            await db.SaveChangesAsync();
                            MessageBox.Show("Заказ успешно создан!");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Окончание заказа должно быть минимум через день после его начала!");
                        }
                    }
                }
            }
        }


        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var service = (((sender as PackIcon).Parent) as Grid).DataContext as string;
            SelectedServices.Remove(service);
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            var clientsWindow = new ClientsListWindow();
            if (clientsWindow.ShowDialog() == true)
            {
                SelectedClient = clientsWindow.SelectedClient;
            }
        }
    }
}
