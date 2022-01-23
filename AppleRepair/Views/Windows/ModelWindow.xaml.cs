using AppleRepair.Data;
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
    /// Логика взаимодействия для ModelWindow.xaml
    /// </summary>
    public partial class ModelWindow : BaseWindow
    {
        private bool isOperationAdd;
        private string phoneModelName;
        private Data.Color selectedColor;
        private PhoneModel currentPhoneModel;
        public ModelWindow(bool isOperationAdd = true, PhoneModel model = null)
        {
            InitializeComponent();
            DataContext = this;
            LoadColors();
            IsOperationAdd = isOperationAdd;
            if (model != null)
            {
                currentPhoneModel = model;
            }
            if (!IsOperationAdd)
            {
                PhoneModelName = currentPhoneModel.ModelName;
                SelectedColor = Colors.FirstOrDefault(p => p.Id == currentPhoneModel.ColorId);
            }

        }
        public string PhoneModelName { get { return phoneModelName; } set { phoneModelName = value; OnPropertyChanged(); } }
        public bool IsOperationAdd { get { return isOperationAdd; } set { isOperationAdd = value; OnPropertyChanged(); } }
        public Data.Color SelectedColor { get { return selectedColor; } set { selectedColor = value; OnPropertyChanged(); } }
        public List<Data.Color> Colors { get; set; }

        private void LoadColors()
        {
            using (var db = new AppleRepairContext())
            {
                Colors = db.Color.ToList();
                SelectedColor = Colors.FirstOrDefault();
            }
        }

        private bool Validate()
        {
            if (!string.IsNullOrEmpty(PhoneModelName) && PhoneModelName.ToLower().Contains("iphone "))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Название модели введено неверно!");
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
                        var model = new PhoneModel
                        {
                            ColorId = SelectedColor.Id,
                            ModelName = PhoneModelName
                        };
                        if (db.PhoneModel.Include("Color").FirstOrDefault(p => p.ModelName.Equals(model.ModelName) && p.Color.Id.Equals(model.ColorId)) == null)
                        {
                            db.PhoneModel.Add(model);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Модель успешно создана!");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Данная модель уже существует!");
                        }
                    }
                }
                else
                {
                    using (var db = new AppleRepairContext())
                    {
                        var model = db.PhoneModel.FirstOrDefault(p => p.Id == currentPhoneModel.Id);
                        var d = model.Id;
                        if (db.PhoneModel.Include("Color").FirstOrDefault(p => p.ModelName.Equals(model.ModelName) && p.Color.Id.Equals(SelectedColor.Id)) == null)
                        {
                            model.ColorId = SelectedColor.Id;
                            if (db.PhoneModel.FirstOrDefault(p => p.ModelName.Equals(currentPhoneModel.ModelName) && p.Color.Id == SelectedColor.Id) == null)
                            {
                                await db.SaveChangesAsync();
                                MessageBox.Show("Модель успешно создана!");
                                this.DialogResult = true;
                            }
                            else
                            {
                                MessageBox.Show("Данная модель уже есть в списке!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Данная модель уже существует!");
                        }
                    }
                }
            }
        }
    }
}

