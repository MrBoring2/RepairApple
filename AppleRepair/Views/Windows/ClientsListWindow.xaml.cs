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
using System.Windows.Shapes;

namespace AppleRepair.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientsListWindow.xaml
    /// </summary>
    public partial class ClientsListWindow : BaseWindow
    {
        private int itemsPerPage;
        private string search;
        private int currentPage;
        private ObservableCollection<Client> displayedClients;
        private Client selectedClient;
        public ClientsListWindow()
        {          
            InitializeFields();
            InitializeComponent();
            DataContext = this;
        }
        private async void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;

            await Task.Run(LoadClients);

            //await Task.Run(LoadColors);

        }
        public Client SelectedClient { get { return selectedClient; } set { selectedClient = value; OnPropertyChanged(); } }
        public List<Client> Clients { get; set; }
       // public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshMaterials(); OnPropertyChanged(); } }
        public ObservableCollection<Client> DisplayedClients { get => displayedClients; set { displayedClients = value; OnPropertyChanged(); } }
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
                RefreshClients();
            }
        }
        public int CurrentPage
        {
            get => currentPage;
            set
            {

                currentPage = value;
                OnPropertyChanged();
                RefreshClients();
            }
        }
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        private async void LoadClients()
        {
            using (var db = new AppleRepairContext())
            {
                await Task.Run(() => Clients = new List<Client>(db.Client));
                //DisplayedClients = new ObservableCollection<Client>(Clients);

               // IsAcsending = true;
                await Task.Run(() => RefreshClients());
                

            }
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
        private void RefreshClients()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }


            var list = Clients; // SortMaterials();

            list = list
              .Where(p => p.Email.ToString().Contains(Search.ToLower()) || p.FullName.ToLower().Contains(Search.ToLower()) || p.PhoneNumber.Contains(Search.ToLower())).ToList();

            // list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

            list = list.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage).ToList();

            DisplayedClients = new ObservableCollection<Client>(list);

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
                var list = Clients
                    .Where(p => p.Email.ToString().Contains(Search.ToLower()) || p.FullName.ToLower().Contains(Search.ToLower()) || p.PhoneNumber.Contains(Search.ToLower())).ToList();

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
            await Task.Run(() => LoadClients());
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow();
            if (orderWindow.ShowDialog() == true)
            {

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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

