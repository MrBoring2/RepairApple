﻿using AppleRepair.Data;
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
        private string description;
        private PhoneModel selectedModel;
        private string selectedService;
        private string selectedServiceInList;
        private Client selectedClient;
        private DateTime date;
        private DateTime time;
        private ObservableCollection<string> selectedServices;
        public OrderWindow()
        {

            InitializeComponent();

            DataContext = this;
            SelectedServices = new ObservableCollection<string>();
            Date = DateTime.Now.ToLocalTime();
            Time = DateTime.Now.ToLocalTime();
            LoadModels();
            LoadServices();
        }

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
                Models = db.PhoneModel.ToList();
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
            var descriptionRange = new TextRange(descriptionText.Document.ContentStart, descriptionText.Document.ContentEnd);
            if (!string.IsNullOrEmpty(descriptionRange.Text)
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (var db = new AppleRepairContext())
                {
                    var descriptionRange = new TextRange(descriptionText.Document.ContentStart, descriptionText.Document.ContentEnd);
                    var order = new Order
                    {
                        StartDate = DateTime.Now.ToLocalTime(),
                        EmployeeId = UserService.Instance.CurrentUser.Id,
                        ClientId = SelectedClient.Id,
                        EndDate = Date.AddHours(Time.Hour).AddMinutes(Time.Minute).AddSeconds(Time.Second),
                        Decription = descriptionRange.Text,

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
                    await db.SaveChangesAsync();
                    MessageBox.Show("Заказ успешно создан!");
                    this.DialogResult = true;
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