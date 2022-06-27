using AppleRepair.Data;
using AppleRepair.Models;
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
    /// Логика взаимодействия для ModelsListPage.xaml
    /// </summary>
    public partial class ModelsListPage : BasePage
    {
        private bool isAcsending;
        private int currentPage;
        private int itemsPerPage;
        private string selectedColor;
        private string search;
        private SortParam selectedSort;
        private ObservableCollection<PhoneModel> displayedModels;
        private PhoneModel selectedModel;
        public ModelsListPage()
        {
            InitializeFields();
        }
        public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshModels(); OnPropertyChanged(); } }
        public SortParam SelectedSort { get => selectedSort; set { selectedSort = value; RefreshModels(); OnPropertyChanged(); } }
        public string SelectedColor { get { return selectedColor; } set { selectedColor = value; RefreshModels(); OnPropertyChanged(); } }
        public List<string> Colors { get; set; }
        public PhoneModel SelectedModel { get { return selectedModel; } set { selectedModel = value; OnPropertyChanged(); } }

        public List<PhoneModel> Models { get; set; }
        public List<SortParam> SortParams { get; set; }
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        public ObservableCollection<PhoneModel> DisplayedModels { get => displayedModels; set { displayedModels = value; OnPropertyChanged(); } }
        public string Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
                RefreshModels();
            }
        }
        public string DisplayedPages
        {
            get => $"{CurrentPage + 1}/{MaxPage}";
        }
        public int CurrentPage
        {
            get => currentPage;
            set
            {

                currentPage = value;
                OnPropertyChanged();
                RefreshModels();
            }
        }
        private async void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;

            await Task.Run(LoadModels);

            await Task.Run(LoadColors);

            IsAcsending = true;
            InitializeComponent();
            DataContext = this;
        }

        private void LoadModels()
        {
            using (var db = new AppleRepairContext())
            {
                Models = new List<PhoneModel>(db.PhoneModel.Include("Color"));
            }
        }

        private void LoadColors()
        {
            using (var db = new AppleRepairContext())
            {
                Colors = new List<string>();
                Colors.Add("Все");
                foreach (var item in db.Color)
                {
                    Colors.Add(item.Name);
                }
                selectedColor = Colors.FirstOrDefault();
            }
        }
        private List<PhoneModel> SortMaterials()
        {
            if (IsAcsending)
            {
                return Models.OrderBy(p => p.ModelName).ToList();
            }
            else
            {
                return Models.OrderByDescending(p => p.ModelName).ToList();
            }
        }
        private void RefreshModels()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }

            var list = SortMaterials();

            list = list
              .Where(p => p.ModelName.ToLower().Contains(Search.ToLower())).ToList();

            list = list.Where(p => SelectedColor != "Все" ? p.Color.Name.Equals(SelectedColor) : p.Color.Name.Contains("")).ToList();

            list = list.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage).ToList();

            DisplayedModels = new ObservableCollection<PhoneModel>(list);

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
                var list = Models
                         .Where(p => p.ModelName.ToLower().Contains(Search.ToLower())).ToList();

                //Фильтруем список клиентов по полу
                list = list.Where(p => SelectedColor != "Все" ? p.Color.Name.Equals(SelectedColor) : p.Color.Name.Contains("")).ToList();

                return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) > 0 ? (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) : 1;
            }
        }
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ToFirst_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = 0;
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

        private void ToLast_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = MaxPage - 1;
        }


        private void remove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //var icon = sender as PackIcon;
            //var par = ((icon.Parent as StackPanel).Parent as Grid);
            //var model = par.DataContext as PhoneModel;
            //using (var db = new AppleRepairContext())
            //{
            //    db.PhoneModel.Attach(model);
            //    model
            //}
        }

        private async void edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = (icon.Parent as StackPanel).Parent as Grid;
            var model = par.DataContext as PhoneModel;
            var modelWindow = new ModelWindow(false, model) { Title = "APPLE СЕРВИС | Редактирование модели" };
            if (modelWindow.ShowDialog() == true)
            {
                await Task.Run(LoadModels);
                await Task.Run(RefreshModels);
            }
        }

        private async void addNewModel_Click(object sender, RoutedEventArgs e)
        {
            var modelWindow = new ModelWindow();
            if (modelWindow.ShowDialog() == true)
            {
                await Task.Run(LoadModels);
                await Task.Run(RefreshModels);
            }
        }
    }
}
