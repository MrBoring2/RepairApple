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
        private ObservableCollection<DeliveryMaterial> selectedMaterials;
        public DeliveryWindow()
        {
            InitializeComponent();

            SelectedMaterials = new ObservableCollection<DeliveryMaterial>();
            using (var db = new AppleRepairContext())
            {
                Suppliers = db.Supplier.ToList();
            }
            SelectedSupplier = Suppliers.FirstOrDefault();
            UpdateTotalPrice();
            DataContext = this;
        }
        public Supplier SelectedSupplier { get => selectedSupplier; set { selectedSupplier = value; OnPropertyChanged(); } }
        public List<Supplier> Suppliers { get; set; }
        public ObservableCollection<DeliveryMaterial> SelectedMaterials
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
            var material = ((sender as PackIcon).Parent as Grid).DataContext as DeliveryMaterial;
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
                        var spendedMaterial = new DeliveryMaterial(materialsListWindow.SelectedMaterial, 1);
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
        private async void delivery_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AppleRepairContext())
            {
                if (SelectedMaterials.Count > 0)
                {
                    var delivery = new Delivery
                    {
                        Date = DateTime.Now.ToLocalTime(),
                        SupplierId = SelectedSupplier.Id,
                    };
                    delivery.MaterialInDelivery = new List<MaterialInDelivery>();
                    foreach (var item in SelectedMaterials)
                    {
                        delivery.MaterialInDelivery.Add(new MaterialInDelivery { Amount = item.Amount, MaterialId = item.Material.Id });
                    }
                    await db.SaveChangesAsync();

                    foreach (var item in delivery.MaterialInDelivery)
                    {
                        var material = db.Material.Find(item.MaterialId);
                        material.Amount += item.Amount;
                    }

                    await db.SaveChangesAsync();

                    MessageBox.Show("Поставка успешно заказана!");
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("В поставку не входит ни одного материала!");
                }
            }
        }
    }
}
