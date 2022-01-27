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
    /// Логика взаимодействия для EmployeesListPage.xaml
    /// </summary>
    public partial class EmployeesListPage : BasePage
    {
        private bool isAcsending;
        private int currentPage;
        private int itemsPerPage;
        private string search;
        private ObservableCollection<Employee> displayedEmployees;
        private Employee selectedEmployee;
        public EmployeesListPage()
        {
            InitializeFields();
        }
        public bool IsAcsending { get { return isAcsending; } set { isAcsending = value; RefreshEmployees(); OnPropertyChanged(); } }

        public List<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get { return selectedEmployee; } set { selectedEmployee = value; OnPropertyChanged(); } }

        public int ItemsPerPage
        {
            get { return itemsPerPage; }
            set { itemsPerPage = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Employee> DisplayedEmployees { get => displayedEmployees; set { displayedEmployees = value; OnPropertyChanged(); } }
        public string Search
        {
            get => search;
            set
            {
                search = value;
                OnPropertyChanged();
                RefreshEmployees();
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
                RefreshEmployees();
            }
        }
        private async void InitializeFields()
        {
            ItemsPerPage = 20;
            search = String.Empty;

            await Task.Run(LoadEmployees);

            IsAcsending = true;
            InitializeComponent();
            DataContext = this;
        }

        private void LoadEmployees()
        {
            using (var db = new AppleRepairContext())
            {
                Employees = new List<Employee>(db.Employee);
            }
        }
     
        private List<Employee> SortMaterials()
        {
            if (IsAcsending)
            {
                return Employees.OrderBy(p => p.FullName).ToList();
            }
            else
            {
                return Employees.OrderByDescending(p => p.FullName).ToList();
            }
        }
        private void RefreshEmployees()
        {
            if (CurrentPage > MaxPage - 1)
            {
                currentPage = MaxPage - 1;
            }

            var list = SortMaterials();

            list = list
              .Where(p => p.FullName.ToLower().Contains(Search.ToLower())).ToList();           

            list = list.Skip(currentPage * ItemsPerPage).Take(ItemsPerPage).ToList();

            DisplayedEmployees = new ObservableCollection<Employee>(list);

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
                var list = Employees
                         .Where(p => p.FullName.ToLower().Contains(Search.ToLower())).ToList();
    

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

        private async void remove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = (icon.Parent as StackPanel).Parent as Grid;
            var employee = par.DataContext as Employee;
            using (var db = new AppleRepairContext())
            {
                if (employee != null)
                {
                    db.Employee.Attach(employee);
                    employee.IsActive = false;
                    await Task.Run(() => db.SaveChangesAsync());
                    await Task.Run(LoadEmployees);
                    await Task.Run(RefreshEmployees);
                }
            }
        }


        private async void edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = (icon.Parent as StackPanel).Parent as Grid;
            var model = par.DataContext as Employee;
            var modelWindow = new EmployeeWindow(false, model) { Title = "APPLE СЕРВИС | Редактирование сотрудника" };
            if (modelWindow.ShowDialog() == true)
            {
                await Task.Run(LoadEmployees);
                await Task.Run(RefreshEmployees);
            }
        }
        private async void restore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var icon = sender as PackIcon;
            var par = ((icon.Parent as StackPanel).Parent as Grid);
            var employee = par.DataContext as Employee;
            using (var db = new AppleRepairContext())
            {
                if (employee != null)
                {
                    db.Employee.Attach(employee);
                    employee.IsActive = true;
                    await Task.Run(() => db.SaveChangesAsync());
                    await Task.Run(LoadEmployees);
                    await Task.Run(RefreshEmployees);
                }
            }
        }
        private async void addNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            var modelWindow = new ModelWindow();
            if (modelWindow.ShowDialog() == true)
            {
                await Task.Run(LoadEmployees);
                await Task.Run(RefreshEmployees);
            }
        }
    }
}
