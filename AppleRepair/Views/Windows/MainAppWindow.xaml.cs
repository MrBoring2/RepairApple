using AppleRepair.Models;
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
    /// Логика взаимодействия для MainAppWindow.xaml
    /// </summary>
    public partial class MainAppWindow : BaseWindow
    {
        private string userFullName;
        private Uri userIcon;
        private string windowTitle;
        private ItemMenu selectedItemMenu;
        private ObservableCollection<ItemMenu> menuItems;
        private ObservableCollection<ItemMenu> optionalMenuItems;
        public MainAppWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadUser();
            LoadMenu();
            SelectedItemMenu = MenuItems.FirstOrDefault();
        }


        public string UserFullName { get { return userFullName; } set { userFullName = value; OnPropertyChanged(); } }
        public Uri UserIcon { get { return userIcon; } set { userIcon = value; OnPropertyChanged(); } }
        public string WindowTitle { get { return windowTitle; } set { windowTitle = value; OnPropertyChanged(); } }
        public ItemMenu SelectedItemMenu
        {
            get
            {
                return selectedItemMenu;
            }
            set
            {
                selectedItemMenu = value;
                if (SelectedItemMenu == OptionalMenuItems.FirstOrDefault())
                {
                    UserService.Instance.Logout();
                    var loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();
                }


                WindowTitle = $"APPLE СЕРВИС | {SelectedItemMenu.Title}";
                pageContainer.Navigate(SelectedItemMenu.Destination);



                OnPropertyChanged();
            }
        }
        public ObservableCollection<ItemMenu> MenuItems { get { return menuItems; } set { menuItems = value; OnPropertyChanged(); } }
        public ObservableCollection<ItemMenu> OptionalMenuItems { get { return optionalMenuItems; } set { optionalMenuItems = value; OnPropertyChanged(); } }
        private void LoadMenu()
        {
            MenuItems = new ObservableCollection<ItemMenu>
            {
                new ItemMenu("Заказы", MaterialDesignThemes.Wpf.PackIconKind.FileDocumentEdit, new Uri("Views/Pages/OrdersListPage.xaml", UriKind.Relative)),
                new ItemMenu("Модели Apple", MaterialDesignThemes.Wpf.PackIconKind.Apple, new Uri("Views/Pages/ModelsListPage.xaml", UriKind.Relative)),
                new ItemMenu("Материалы", MaterialDesignThemes.Wpf.PackIconKind.SemanticWeb, new Uri("Views/Pages/MaterialsListPage.xaml", UriKind.Relative))
            };
            OptionalMenuItems = new ObservableCollection<ItemMenu>
            {
                new ItemMenu("Выход", MaterialDesignThemes.Wpf.PackIconKind.LocationExit, null)
            };
        }
        private void LoadUser()
        {
            UserFullName = UserService.Instance.CurrentUser.FullName;
            switch (UserService.Instance.CurrentUser.RoleId)
            {
                case 1:
                    {
                        UserIcon = new Uri("Resources/Images/master.png", UriKind.Relative);
                    }
                    break;
                case 2:
                    {
                        UserIcon = new Uri("Resources/Images/administrator.png", UriKind.Relative);
                    }
                    break;
                default:
                    {
                        UserIcon = new Uri("Resources/Images/not_found_user.png", UriKind.Relative);
                    }
                    break;
            }
        }

        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
