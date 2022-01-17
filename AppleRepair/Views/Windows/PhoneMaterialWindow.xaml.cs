using AppleRepair.Data;
using AppleRepair.Services;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
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
    /// Логика взаимодействия для MaterialWindow.xaml
    /// </summary>
    public partial class PhoneMaterialWindow : BaseWindow
    {
        private MaterialType selectedMaterialType;
        private Material selectedMaterial;
        private ObservableCollection<Material> selectedMaterials;
        public PhoneMaterialWindow()
        {
            LoadTypes();
            InitializeComponent();
            DataContext = this;
        }
        public List<Material> Materials { get; set; }
        public List<MaterialType> MaterialTypes { get; set; }
        public MaterialType SelectedMaterialType { get => selectedMaterialType; set { selectedMaterialType = value; OnPropertyChanged(); } }
        public ObservableCollection<Material> SelectedMaterials { get=>SelectedMaterials; set { selectedMaterials = value; OnPropertyChanged(); } }
        public Material SelectedMaterial { get => selectedMaterial; set { selectedMaterial = value; SelectedMaterials.Add(SelectedMaterial);  OnPropertyChanged(); } }
        private void LoadTypes()
        {
            using (var db = new AppleRepairContext())
            {
                MaterialTypes = db.MaterialType.OrderBy(p => p.Name).ToList();
                SelectedMaterialType = MaterialTypes.FirstOrDefault();
            }
        }
        private void LoadMaterials()
        {
            using (var db = new AppleRepairContext())
            {
                Materials = db.Material.OrderBy(p => p.Name).ToList();
            }
        }

    }
}
