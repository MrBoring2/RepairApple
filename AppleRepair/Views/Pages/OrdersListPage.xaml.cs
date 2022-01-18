using AppleRepair.Data;
using AppleRepair.Views.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppleRepair.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrdersListPage : BasePage
    {
        private int itemsPerPage;
        private string search;
        private bool isAcsending;
        private int currentPage;
        private string selectedModel;
        private string selectedStatus;
        private ObservableCollection<Order> displayedOrders;
        private Order selectedOrder;
        public OrdersListPage()
        {
            InitializeFields();
        }
        private async void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;


            await Task.Run(LoadOrders);
            LoadStatuses();
            LoadModels();
            InitializeComponent();
            DataContext = this;
            //await Task.Run(LoadColors);

        }
        public string SelectedStatus { get { return selectedStatus; } set { selectedStatus = value; OnPropertyChanged(); RefreshOrders(); } }
        public string SelectedModel { get { return selectedModel; } set { selectedModel = value; OnPropertyChanged(); RefreshOrders(); } }
        public List<string> Statuses { get; set; }
        public List<string> Models { get; set; }
        public Order SelectedOrder { get { return selectedOrder; } set { selectedOrder = value; OnPropertyChanged(); } }
        public List<Order> Orders { get; set; }
        public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshOrders(); OnPropertyChanged(); } }
        public ObservableCollection<Order> DisplayedOrders { get => displayedOrders; set { displayedOrders = value; OnPropertyChanged(); } }
        public string DisplayedPages
        {
            get => $"{CurrentPage + 1}/{MaxPage}";
        }
        public string Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
                RefreshOrders();
            }
        }
        public int CurrentPage
        {
            get => currentPage;
            set
            {

                currentPage = value;
                OnPropertyChanged();
                RefreshOrders();
            }
        }
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        private async void LoadOrders()
        {
            using (var db = new AppleRepairContext())
            {
                Orders = new List<Order>(db.Order.Include("Client").Include("PhoneModel"));
                DisplayedOrders = new ObservableCollection<Order>(Orders);

                IsAcsending = true;
                await Task.Run(() => RefreshOrders());
            }
        }
        private void LoadStatuses()
        {
            Statuses = new List<string>
            {
                "Все",
                "В процессе выполнения",
                "Завершён",
                "Отменён"
            };
            SelectedStatus = Statuses.FirstOrDefault();

        }
        private void LoadModels()
        {
            using (var db = new AppleRepairContext())
            {
                Models = new List<string>();
                Models.Add("Все");
                var models = db.PhoneModel.ToList();
                foreach (var item in models)
                {
                    Models.Add(item.ModelName);
                }
                Models = Models.Distinct().ToList();
                SelectedModel = Models.FirstOrDefault();
            }
        }

        private List<Order> SortOrders()
        {
            if (IsAcsending)
            {
                return Orders.OrderBy(p => p.Id).ToList();
            }
            else
            {
                return Orders.OrderByDescending(p => p.Id).ToList();
            }
        }
        private void RefreshOrders()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }


            var list = SortOrders();

            list = list
              .Where(p => p.Id.ToString().Contains(Search.ToLower()) || p.Client.FullName.ToLower().Contains(Search.ToLower())).ToList();

            list = list.Where(p => SelectedModel != "Все" ? p.PhoneModel.ModelName.Equals(SelectedModel) : p.PhoneModel.ModelName.Contains("")).ToList();

            list = list.Where(p => SelectedStatus != "Все" ? p.Status.Equals(SelectedStatus) : p.Status.Contains("")).ToList();

            list = list.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage).ToList();

            DisplayedOrders = new ObservableCollection<Order>(list);

            OnPropertyChanged(nameof(DisplayedPages));

            //Если после фильтрации у нас количество элементов 0, то выводим Пусто
            //if (DisplayedClients.Count <= 0)
            //{
            //    EmptyVisibility = Visibility.Visible;
            //    Paginator.SelectedPageNumber = 1;
            //}
            //else EmptyVisibility = Visibility.Hidden;

        }

        private int MaxPage
        {
            get
            {
                //Фильтруем наш список по поисковой строке
                var list = Orders
                         .Where(p => p.Id.ToString().Contains(Search.ToLower()) || p.Client.FullName.ToLower().Contains(Search.ToLower())).ToList();

                list = list.Where(p => SelectedModel != "Все" ? p.PhoneModel.ModelName.Equals(SelectedModel) : p.PhoneModel.ModelName.Contains("")).ToList();

                list = list.Where(p => SelectedStatus != "Все" ? p.Status.Equals(SelectedStatus) : p.Status.Contains("")).ToList();

                return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) > 0 ? (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) : 1;
            }
        }
        private void ToFirst_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = 0;
        }


        private void ToLast_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = MaxPage - 1;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => LoadOrders());
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FinishOrder_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < MaxPage - 1)
            {
                CurrentPage++;
            }
        }



        private void check_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = ((icon.Parent as StackPanel).Parent as Grid);
            var order = par.DataContext as Order;
            if (order != null)
            {
                if (order.Status == "В процессе выполнения")
                {
                    var finishOrderWindow = new FinishOrderWindow(order);
                    if (finishOrderWindow.ShowDialog() == true)
                    {
                        LoadOrders();
                    }
                }
                else
                {
                    MessageBox.Show("Заказ уже выполнени или отменён!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private async void restore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = ((icon.Parent as StackPanel).Parent as Grid);
            var order = par.DataContext as Order;
            using (var db = new AppleRepairContext())
            {
                if (order != null)
                {
                    if (order.Status == "Отменён")
                    {
                        order.Status = "В процессе выполнения";
                        db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                        await db.SaveChangesAsync();
                        await Task.Run(LoadOrders);
                    }
                    else
                    {
                        MessageBox.Show("Заказ не отменён!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }

        }

        private async void cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = ((icon.Parent as StackPanel).Parent as Grid);
            var order = par.DataContext as Order;
            using (var db = new AppleRepairContext())
            {
                if (order != null)
                {
                    if (order.Status == "В процессе выполнения")
                    {
                        order.Status = "Отменён";
                        db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                        await db.SaveChangesAsync();
                        await Task.Run(LoadOrders);
                    }
                    else
                    {
                        MessageBox.Show("Заказ уже отменён или выполнен!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void addNewOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow();
            if (orderWindow.ShowDialog() == true)
            {
                LoadOrders();
            }
        }
    }
}
