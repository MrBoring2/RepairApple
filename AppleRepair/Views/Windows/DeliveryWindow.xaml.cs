using AppleRepair.Data;
using AppleRepair.Models;
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
    /// Логика взаимодействия для DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : BaseWindow
    {
        private double totalPrice;
        private Supplier selectedSupplier;
        private ObservableCollection<SpendedMaterial> selectedMaterials;
        public DeliveryWindow()
        {
            InitializeComponent();

            SelectedMaterials = new ObservableCollection<SpendedMaterial>();
            using (var db = new AppleRepairContext())
            {
                Suppliers = db.Supplier.ToList();
            }
            UpdateTotalPrice();
            DataContext = this;
        }
        public Supplier SelectedSupplier { get => selectedSupplier; set { selectedSupplier = value; OnPropertyChanged(); } }
        public List<Supplier> Suppliers { get; set; }
        public ObservableCollection<SpendedMaterial> SelectedMaterials
        {
            get { return selectedMaterials; }
            set { selectedMaterials = value; OnPropertyChanged(); }
        }
        public double TotalPrice { get { return totalPrice; } set { totalPrice = value; OnPropertyChanged(); } }


        private void UpdateTotalPrice()
        {
            double price = 0;
            foreach (var item in SelectedMaterials)
            {
                price += item.Material.Price * (double)item.Amount;
            }
            TotalPrice = price;
        }
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var material = ((sender as PackIcon).Parent as Grid).DataContext as SpendedMaterial;
            SelectedMaterials.Remove(material);
            UpdateTotalPrice();
        }
        private void SpendedMaterial_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateTotalPrice();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            var materialsListWindow = new MaterialsListWindow();
            if (materialsListWindow.ShowDialog() == true)
            {
                using (var db = new AppleRepairContext())
                {
                    var material = materialsListWindow.SelectedMaterial;

                    if (SelectedMaterials.FirstOrDefault(p => p.Material.Id == material.Id) == null)
                    {
                        var spendedMaterial = new SpendedMaterial(materialsListWindow.SelectedMaterial, 1);
                        spendedMaterial.PropertyChanged += SpendedMaterial_PropertyChanged;
                        SelectedMaterials.Add(spendedMaterial);
                        UpdateTotalPrice();
                    }
                    else
                    {
                        MessageBox.Show("Материал уже в списке!");
                    }
                }
            }
        }
    }
}
