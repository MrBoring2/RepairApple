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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : BaseWindow
    {
        private bool isOperationAdd;
        public EmployeeWindow(bool isOperationAdd = true, Employee employee = null)
        {
            InitializeComponent();
            this.isOperationAdd = isOperationAdd;
            this.CurrentEmployee = employee;
        }
        public Employee CurrentEmployee { get; set; }
    }
}
