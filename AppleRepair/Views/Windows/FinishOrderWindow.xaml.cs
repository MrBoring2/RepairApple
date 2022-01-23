using AppleRepair.Data;
using AppleRepair.Models;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;
using System.Windows.Documents;
using System.Collections.Generic;

namespace AppleRepair.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : BaseWindow
    {
        private double totalPrice;
        private ObservableCollection<SpendedMaterial> spendedMaterials;
        public FinishOrderWindow(Order order)
        {
            InitializeComponent();
            CurrentOrder = order;
            Services = new List<Service>();
            SpendedMaterials = new ObservableCollection<SpendedMaterial>();
            using (var db = new AppleRepairContext())
            {
                db.Order.Attach(CurrentOrder);
                Services.AddRange(CurrentOrder.Service);
            }
            UpdateTotalPrice();
            DataContext = this;
        }
        public ObservableCollection<SpendedMaterial> SpendedMaterials
        {
            get { return spendedMaterials; }
            set { spendedMaterials = value; OnPropertyChanged(); }
        }
        public List<Service> Services { get; set; }
        public double TotalPrice { get { return totalPrice; } set { totalPrice = value; OnPropertyChanged(); } }
        private Order CurrentOrder { get; set; }
        public string ClientFullName => CurrentOrder.Client.FullName;
        public string PhoneModel => $"{CurrentOrder.PhoneModel.ModelName} | {CurrentOrder.PhoneModel.Color.Name}";
        public DateTime StartDate => CurrentOrder.StartDate;
        public DateTime EndDate => CurrentOrder.EndDate;
        public string Description => CurrentOrder.Decription.Replace("\r\n", "");
        private void UpdateTotalPrice()
        {
            //double price = 0;
            //foreach (var item in SpendedMaterials)
            //{
            //    price += item.Material.Price * (double)item.Amount;
            //}
            //TotalPrice = price;
            using (var db = new AppleRepairContext())
            {
                db.Order.Attach(CurrentOrder);

                TotalPrice = CurrentOrder.Service.Sum(p => p.Price);
            }
        }
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var material = ((sender as PackIcon).Parent as Grid).DataContext as SpendedMaterial;
            SpendedMaterials.Remove(material);
            //UpdateTotalPrice();
        }


        private void SelectMaterial_Click(object sender, RoutedEventArgs e)
        {
            var materialsListWindow = new MaterialsListWindow();
            if (materialsListWindow.ShowDialog() == true)
            {
                using (var db = new AppleRepairContext())
                {
                    db.Order.Attach(CurrentOrder);
                    var material = materialsListWindow.SelectedMaterial;
                    if (CurrentOrder.PhoneModel.Material.FirstOrDefault(p => p.Id == material.Id) != null)
                    {
                        if (SpendedMaterials.FirstOrDefault(p => p.Material.Id == material.Id) == null)
                        {
                            var spendedMaterial = new SpendedMaterial(materialsListWindow.SelectedMaterial, 1);
                            spendedMaterial.PropertyChanged += SpendedMaterial_PropertyChanged;
                            SpendedMaterials.Add(spendedMaterial);
                            //UpdateTotalPrice();
                        }
                        else
                        {
                            MessageBox.Show("Материал уже в списке!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Материал не поддерживается для данной модели!");
                    }

                }
            }
        }

        private void SpendedMaterial_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //UpdateTotalPrice();
        }

        private async void FinishOrder_Click(object sender, RoutedEventArgs e)
        {
            if (SpendedMaterials.Count > 0)
            {
                using (var db = new AppleRepairContext())
                {
                    var order = db.Order.Find(CurrentOrder.Id);
                    db.Entry(order).Collection(p => p.MaterialToOrder).Load();
                    foreach (var item in SpendedMaterials)
                    {
                        order.MaterialToOrder.Add(new MaterialToOrder { MaterialId = item.Material.Id, Amount = item.Amount, OrderId = order.Id });
                    }
                    order.Status = "Завершён";
                    await Task.Run(() => db.SaveChangesAsync());
                    MessageBox.Show("Заказ успешно закончен!");
                    this.DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Нет потраченных материалов!");
            }
        }
    }
}
