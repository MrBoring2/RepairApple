﻿using AppleRepair.Data;
using AppleRepair.Views.Windows;
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
            InitializeComponent();
            DataContext = this;
            //await Task.Run(LoadColors);

        }
        public Order SelectedOrder { get { return selectedOrder; } set { selectedOrder = value; OnPropertyChanged(); } }
        public List<Order> Orders { get; set; }
        public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshMaterials(); OnPropertyChanged(); } }
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
                RefreshMaterials();
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

        private async void RefreshOrders()
        {
            await Task.Run(() =>
            {
                var list = Orders.ToList();

                DisplayedOrders = new ObservableCollection<Order>(list);
            });
        }
        private List<Material> SortMaterials()
        {
            //if (IsAcsending)
            //{
            //    return Orders.OrderBy(p => p.GetValue(SelectedSort.Property)).ToList();
            //}
            //else
            //{
            //    return Materials.OrderByDescending(p => p.GetValue(SelectedSort.Property)).ToList();
            //}
            return null;
        }
        private void RefreshMaterials()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }


            var list = Orders; // SortMaterials();

            list = list
              .Where(p => p.Id.ToString().Contains(Search.ToLower()) || p.Client.FullName.ToLower().Contains(Search.ToLower())).ToList();

           // list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

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

                //Фильтруем список клиентов по полу
                //list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

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
            var orderWindow = new OrderWindow();
            if(orderWindow.ShowDialog() == true)
            {
                LoadOrders();
            }
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
    }
}
