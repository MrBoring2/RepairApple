using AppleRepair.Data;
using AppleRepair.Models;
using AppleRepair.Services;
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
    /// Логика взаимодействия для MaterialsListPage.xaml
    /// </summary>
    public partial class MaterialsListPage : BasePage
    {
        private bool isAcsending;
        private int currentPage;
        private int itemsPerPage;
        private string selectedMaterialType;
        private string search;
        private SortParam selectedSort;
        private ObservableCollection<Material> displayedMaterials;
        private Material selectedMaterial;
        public MaterialsListPage()
        {
            InitializeComponent();
            DataContext = this;

            InitializeFields();


        }
        public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshMaterials(); OnPropertyChanged(); } }
        public SortParam SelectedSort { get => selectedSort; set { selectedSort = value; RefreshMaterials(); OnPropertyChanged(); } }
        public string SelectedMaterialType { get { return selectedMaterialType; } set { selectedMaterialType = value; RefreshMaterials(); OnPropertyChanged(); } }
        public List<string> MaterialTypes { get; set; }
        public Paginator Paginator { get; set; }
        public Material SelectedMaterial { get { return selectedMaterial; } set { selectedMaterial = value; OnPropertyChanged(); } }
        //public ObservableCollection<int> DisplayedPagesNumbers
        //{
        //    get => Paginator.DisplayedPagesNumbers;
        //    set { Paginator.DisplayedPagesNumbers = value; OnPropertyChanged(nameof(Paginator.DisplayedPagesNumbers)); }
        //}
        public int SelectedPageNumber
        {
            get => Paginator.SelectedPageNumber;
            set
            {
                Paginator.SelectedPageNumber = value;

                Paginator.RefrashPaginator();
                //RefreshMaterials();
                //OnPropertyChanged();
            }
        }
        public List<Material> Materials { get; set; }
        public List<SortParam> SortParams { get; set; }
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Material> DisplayedMaterials { get => displayedMaterials; set { displayedMaterials = value; OnPropertyChanged(); } }
        public string Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
                RefreshMaterials();
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
                if (value <= 0)
                    currentPage = 1;
                else
                    currentPage = value;
                OnPropertyChanged();
                RefreshMaterials();
            }
        }
        private void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;

            LoadMaterials();

            LoadTypes();
            LoadSort();

            IsAcsending = true;
        }

        private void LoadSort()
        {
            SortParams = new List<SortParam>
            {
                new SortParam("Название", "Name"),
                new SortParam("Цена", "Price")
            };
            selectedSort = SortParams.FirstOrDefault();
        }

        private void LoadMaterials()
        {
            using (var db = new AppleRepairContext())
            {
                Materials = new List<Material>(db.Material.Include("MaterialType"));
            }
        }

        private void LoadTypes()
        {
            using (var db = new AppleRepairContext())
            {
                MaterialTypes = new List<string>();
                MaterialTypes.Add("Все");
                foreach (var item in db.MaterialType)
                {
                    MaterialTypes.Add(item.Name);
                }
                selectedMaterialType = MaterialTypes.FirstOrDefault();
            }
        }
        private List<Material> SortMaterials()
        {
            if (IsAcsending)
            {
                return Materials.OrderBy(p => p.GetValue(SelectedSort.Property)).ToList();
            }
            else
            {
                return Materials.OrderByDescending(p => p.GetValue(SelectedSort.Property)).ToList();
            }
        }
        private void RefreshMaterials()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }

            var list = SortMaterials();

            list = list
              .Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();

            list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

            list = list.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage).ToList();

            DisplayedMaterials = new ObservableCollection<Material>(list);

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
                var list = Materials
                         .Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();

                //Фильтруем список клиентов по полу
                list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

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
    }
}
