using AppleRepair.Data;
using AppleRepair.Models;
using AppleRepair.Services;
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
    /// Логика взаимодействия для MaterialsListPage.xaml
    /// </summary>
    public partial class MaterialsListPage : BasePage
    {
        private Visibility adminVisibility;
        public delegate void SendMaterial(Material material);
        public event SendMaterial onSendMaterial;
        private bool isModal;
        private bool isAcsending;
        private int currentPage;
        private int itemsPerPage;
        private string selectedMaterialType;
        private string search;
        private string selectedRemoveCheck;
        private SortParam selectedSort;
        private ObservableCollection<Material> displayedMaterials;

        private Material selectedMaterial;

        public MaterialsListPage()
        {
            InitializeComponent();
            DataContext = this;
            if (UserService.Instance.CurrentUser.RoleId == 2)
            {
                AdminVisibility = Visibility.Visible;
            }
            else
            {
                AdminVisibility = Visibility.Hidden;
            }
            InitializeFields();
            //OnPropertyChanged(nameof(DisplayedMaterials));
        }
        public MaterialsListPage(bool isModel = false) : this()
        {
            this.isModal = isModel;
        }
        public Visibility AdminVisibility { get => adminVisibility; set { adminVisibility = value; OnPropertyChanged(); } }
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
        public List<string> RemoveCheckCollection { get; set; }
        public List<SortParam> SortParams { get; set; }
        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Material> DisplayedMaterials { get => displayedMaterials; set { displayedMaterials = value; OnPropertyChanged(); } }
        public string SelectedRemoveCheck { get => selectedRemoveCheck; set { selectedRemoveCheck = value; OnPropertyChanged(); RefreshMaterials(); } }
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

                currentPage = value;
                OnPropertyChanged();
                RefreshMaterials();
            }
        }
        private async void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;

            await Task.Run(LoadMaterials);

            await Task.Run(LoadTypes);
            await Task.Run(LoadSort);
            await Task.Run(LoadRemoveCheckCollection);

            isAcsending = true;


            await Task.Run(RefreshMaterials);

            OnPropertyChanged(nameof(MaterialTypes));
            OnPropertyChanged(nameof(RemoveCheckCollection));
            OnPropertyChanged(nameof(SortParams));
            OnPropertyChanged(nameof(SelectedSort));
            OnPropertyChanged(nameof(SelectedMaterialType));
            OnPropertyChanged(nameof(SelectedRemoveCheck));
            OnPropertyChanged(nameof(IsAcsending));
        }

        private void LoadRemoveCheckCollection()
        {
            RemoveCheckCollection = new List<string>
            {
                "Все",
                "Есть",
                "Отсутствует"
            };
            selectedRemoveCheck = RemoveCheckCollection.FirstOrDefault();
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

            if (SelectedRemoveCheck == "Есть")
            {
                list = list.Where(p => p.IsActive == false).ToList();
            }
            else if (SelectedRemoveCheck == "Отсутствует")
            {
                list = list.Where(p => p.IsActive == true).ToList();
            }

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
                if (Materials != null)
                {
                    //Фильтруем наш список по поисковой строке
                    var list = Materials
                             .Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();

                    //Фильтруем список клиентов по полу
                    list = list.Where(p => SelectedMaterialType != "Все" ? p.MaterialType.Name.Equals(SelectedMaterialType) : p.MaterialType.Name.Contains("")).ToList();

                    if (SelectedRemoveCheck == "Есть")
                    {
                        list = list.Where(p => p.IsActive == false).ToList();
                    }
                    else if (SelectedRemoveCheck == "Отсутствует")
                    {
                        list = list.Where(p => p.IsActive == true).ToList();
                    }

                    return (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) > 0 ? (int)Math.Ceiling((float)list.Count / (float)ItemsPerPage) : 1;
                }
                else return 1;
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


        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (isModal)
            {
                if (SelectedMaterial.IsActive == false)
                {
                    MessageBox.Show("Материал не активен!");
                }
                else
                {
                    onSendMaterial?.Invoke(SelectedMaterial);
                }
            }
        }
        private async void edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = (icon.Parent as StackPanel).Parent as Grid;
            var material = par.DataContext as Material;
            var materialWindow = new PhoneMaterialWindow(false, material) { Title = "APPLE СЕРВИС | Редактирование материала" };
            if (materialWindow.ShowDialog() == true)
            {
                await Task.Run(LoadMaterials);
                await Task.Run(RefreshMaterials);
            }
        }

        private async void remove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = (icon.Parent as StackPanel).Parent as Grid;
            var material = par.DataContext as Material;
            using (var db = new AppleRepairContext())
            {
                if (material != null)
                {
                    db.Material.Attach(material);
                    material.IsActive = false;
                    await Task.Run(() => db.SaveChangesAsync());
                    await Task.Run(RefreshMaterials);
                }
            }
        }

        private async void addNewMaterial_Click(object sender, RoutedEventArgs e)
        {
            var materilaWindow = new PhoneMaterialWindow();
            if (materilaWindow.ShowDialog() == true)
            {
                await Task.Run(LoadMaterials);
                await Task.Run(RefreshMaterials);
            }
        }

        private async void restore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = ((icon.Parent as StackPanel).Parent as Grid);
            var material = par.DataContext as Material;
            using (var db = new AppleRepairContext())
            {
                if (material != null)
                {
                    db.Material.Attach(material);
                    material.IsActive = true;
                    await Task.Run(() => db.SaveChangesAsync());
                    await Task.Run(RefreshMaterials);
                }
            }
        }

        private async void deliveryMaterial_Click(object sender, RoutedEventArgs e)
        {
            var deliveryWindow = new DeliveryWindow();
            if (deliveryWindow.ShowDialog() == true)
            {
                await Task.Run(LoadMaterials);
                await Task.Run(RefreshMaterials);
            }
        }
    }
}
