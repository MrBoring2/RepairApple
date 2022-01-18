using AppleRepair.Data;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для FinishOrderWindow.xaml
    /// </summary>
    public partial class FinishOrderWindow : BaseWindow
    {
        public FinishOrderWindow(Order order)
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
