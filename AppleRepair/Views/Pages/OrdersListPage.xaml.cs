using AppleRepair.Data;
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
        private ObservableCollection<Order> displayedOrders;
        private Order selectedOrder;
        public OrdersListPage()
        {
            InitializeComponent();
        }
        public Order SelectedOrder { get { return selectedOrder; } set { selectedOrder = value; OnPropertyChanged(); } }
        public List<Order> Orders { get; set; }
        public ObservableCollection<Order> DisplayedOrders { get => displayedOrders; set { displayedOrders = value; OnPropertyChanged(); } }

        private async void LoadOrders()
        {
            using (var db = new AppleRepairContext())
            {
                await Task.Run(() => Orders = new List<Order>(db.Order));
                DisplayedOrders = new ObservableCollection<Order>(Orders);
                await Task.Run(() => RefreshOrders());
            }
        }

        private async void RefreshOrders()
        {
            await Task.Run(() =>
            {
                var list = Orders.ToList();

                DisplayedOrders = new ObservableCollection<Order>(list);
            });
        }

        private void ToLast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToFirst_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => LoadOrders());
        }
    }
}
