using AppleRepair.Data;
using AppleRepair.Services;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
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
    /// Логика взаимодействия для MaterialWindow.xaml
    /// </summary>
    public partial class PhoneMaterialWindow : BaseWindow
    {
        private Material currentMaterial;
        private Visibility editVisibility;
        private bool isOperationAdd;
        private string materialName;
        private double price;
        private int amount;
        private string description;
        private MaterialType selectedMaterialType;
        private string selectedModel;
        private string selectedModelInList;
        private ObservableCollection<string> selectedModels;
        public PhoneMaterialWindow(bool isOperationAdd = true, Material material = null)
        {

            InitializeComponent();
            IsOperationAdd = isOperationAdd;
            EditVisibility = Visibility.Visible;
            DataContext = this;
            SelectedModels = new ObservableCollection<string>();
            LoadTypes();
            LoadModels();
            if (!isOperationAdd && material != null)
            {
                EditVisibility = Visibility.Hidden;
                MaterialName = material.Name;
                Price = material.Price;
                Amount = material.Amount;
                currentMaterial = material;
                using (var db = new AppleRepairContext())
                {
                    db.Material.Attach(material);
                    var modelsString = new List<string>();
                    foreach (var item in material.PhoneModel)
                    {
                        modelsString.Add(item.ModelName);
                    }
                    SelectedModels = new ObservableCollection<string>(modelsString.Distinct().ToList());
                }
            }

        }
        public string MaterialName { get { return materialName; } set { materialName = value; OnPropertyChanged(); } }
        public Visibility EditVisibility { get { return editVisibility; } set { editVisibility = value; OnPropertyChanged(); } }
        public bool IsOperationAdd { get { return isOperationAdd; } set { isOperationAdd = value; OnPropertyChanged(); } }
        public double Price { get { return price; } set { price = value; OnPropertyChanged(); } }
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public string Description { get { return description; } set { description = value; OnPropertyChanged(); FormatName(); } }
        public List<string> Models { get; set; }
        public List<MaterialType> MaterialTypes { get; set; }
        public MaterialType SelectedMaterialType { get => selectedMaterialType; set { selectedMaterialType = value; OnPropertyChanged(); FormatName(); } }
        public ObservableCollection<string> SelectedModels { get => selectedModels; set { selectedModels = value; OnPropertyChanged(); } }
        public string SelectedModel
        {
            get => selectedModel;
            set
            {
                selectedModel = value;
                if (SelectedModels.FirstOrDefault(p => p.Equals(SelectedModel)) == null)
                    SelectedModels.Add(SelectedModel);
                else
                {
                    MessageBox.Show("Данная модель уже есть в списке!");
                }
                OnPropertyChanged();
                FormatName();
            }
        }
        public string SelectedModelInList { get => selectedModelInList; set { selectedModelInList = value; OnPropertyChanged(); } }
        private void FormatName()
        {
            MaterialName = $"{SelectedMaterialType.Name} для ";
            foreach (var item in SelectedModels)
            {
                if (item != SelectedModels.LastOrDefault())
                    MaterialName += $"{item}/";
                else MaterialName += $"{item} ";
            }
            MaterialName += $"{Description}";
        }
        private void LoadTypes()
        {
            using (var db = new AppleRepairContext())
            {
                MaterialTypes = db.MaterialType.OrderBy(p => p.Name).ToList();
                SelectedMaterialType = MaterialTypes.FirstOrDefault();
            }
        }
        private void LoadModels()
        {
            using (var db = new AppleRepairContext())
            {
                Models = new List<string>();
                var models = db.PhoneModel;
                foreach (var item in models)
                {
                    Models.Add(item.ModelName);
                }
                Models = Models.Distinct().OrderBy(p => p).ToList();
            }
        }

        private bool Validate()
        {
            if (!string.IsNullOrEmpty(MaterialName)
                && SelectedModels.Count > 0
                && Price > 0
                && Amount > 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены верно либо список моделей пуст!");
                return false;
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                if (IsOperationAdd)
                {
                    using (var db = new AppleRepairContext())
                    {
                        var material = new Material
                        {
                            Amount = Amount,
                            MaterialTypeId = db.MaterialType.Find(SelectedMaterialType.Id).Id,
                            Name = MaterialName,
                            Price = Price,
                            IsActive = true
                        };
                        var models = db.PhoneModel.Where(p => SelectedModels.Contains(p.ModelName)).ToList();
                        foreach (var item in models)
                        {
                            item.Material.Add(material);
                        }

                        if (db.Material.FirstOrDefault(p => p.Name.Equals(material.Name)) == null)
                        {
                            db.Material.Add(material);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Материал успешно добавлен!");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Такой материал уже существует!");
                        }
                    }
                }
                else
                {
                    using (var db = new AppleRepairContext())
                    {
                        var material = db.Material.Find(currentMaterial.Id);

                        material.Price = Price;
                        await Task.Run(() => db.SaveChangesAsync());
                        MessageBox.Show("Материал успешно изменён!");
                        this.DialogResult = true;

                    }
                }
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var model = (((sender as PackIcon).Parent) as Grid).DataContext as string;
            SelectedModels.Remove(model);
            FormatName();
        }
    }
}
