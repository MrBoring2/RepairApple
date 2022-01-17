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
        private string phoneModelName;
        private Data.Color selectedColor;
        private DateTime date;
        private DateTime time;
        private ObservableCollection<string> selectedServices;
        public ModelWindow()
        {

            InitializeComponent();

            DataContext = this;
            LoadColors();
        }
        public string PhoneModelName { get { return phoneModelName; } set { phoneModelName = value; OnPropertyChanged(); } }
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
                MessageBox.Show("Назваине модели введено неверно!");
                return false;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                using (var db = new AppleRepairContext())
                {
                    var model = new PhoneModel
                    {
                        ColorId = SelectedColor.Id,
                        ModelName = PhoneModelName
                    };
                    db.PhoneModel.Add(model);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Модель успешно создана!");
                    this.DialogResult = true;
                }
            }
        }
    }
}

