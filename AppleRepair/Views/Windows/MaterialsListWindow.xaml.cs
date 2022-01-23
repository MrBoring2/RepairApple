using AppleRepair.Data;
using AppleRepair.Models;
using AppleRepair.Services;
using AppleRepair.Views.Pages;
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
    /// Логика взаимодействия для MaterialsListWindow.xaml
    /// </summary>
    public partial class MaterialsListWindow : BaseWindow
    {
        public Material SelectedMaterial;
        public MaterialsListWindow()
        {
            InitializeComponent();
            MaterialsListPage materialsListPage = new MaterialsListPage(true);
            materialsListPage.onSendMaterial += MaterialsListPage_onSendMaterial;
            frame.Navigate(materialsListPage);
            DataContext = this;
        }

        private void MaterialsListPage_onSendMaterial(Material material)
        {
            SelectedMaterial = material;
            this.DialogResult = true;
        }
    }
}
