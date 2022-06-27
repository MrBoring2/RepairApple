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
        private string fullName;
        private string login;
        private string password;
        private Role selectedRole;
        private Employee currentEmployee;
        public EmployeeWindow(bool isOperationAdd = true, Employee employee = null)
        {
            InitializeComponent();
            DataContext = this;
            LoadRoles();
            IsOperationAdd = isOperationAdd;
            if (employee != null)
            {
                currentEmployee = employee;
            }
            if (!IsOperationAdd)
            {
                FullName = currentEmployee.FullName;
                Login = currentEmployee.Login;
                Password = currentEmployee.Password;
                SelectedRole = Roles.FirstOrDefault(p => p.Id == currentEmployee.RoleId);
            }

        }
        public string FullName { get { return fullName; } set { fullName = value; OnPropertyChanged(); } }
        public string Login { get { return login; } set { login = value; OnPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }
        public bool IsOperationAdd { get { return isOperationAdd; } set { isOperationAdd = value; OnPropertyChanged(); } }
        public Role SelectedRole { get { return selectedRole; } set { selectedRole = value; OnPropertyChanged(); } }
        public List<Role> Roles { get; set; }

        private void LoadRoles()
        {
            using (var db = new AppleRepairContext())
            {
                Roles = db.Role.ToList();
                SelectedRole = Roles.FirstOrDefault();
            }
        }

        private bool Validate()
        {
            if (!string.IsNullOrEmpty(FullName))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
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
                        var employee = new Employee
                        {
                            RoleId = SelectedRole.Id,
                            FullName = FullName,
                            Login = Login,
                            Password = Password,
                            IsActive = true
                        };
                        if (db.Employee.FirstOrDefault(p => p.Login.Equals(employee.Login)) == null)
                        {
                            db.Employee.Add(employee);
                            await db.SaveChangesAsync();
                            MessageBox.Show("Сотрудник успешно создан!");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                        }
                    }
                }
                else
                {
                    using (var db = new AppleRepairContext())
                    {
                        var employee = db.Employee.FirstOrDefault(p => p.Id == currentEmployee.Id);
                        if (db.Employee.FirstOrDefault(p => p.Login.Equals(employee.Login) && p.Id != employee.Id) == null)
                        {
                            employee.RoleId = SelectedRole.Id;
                            employee.FullName = FullName;
                            employee.Password = Password;
                            employee.Login = Login;
                            await db.SaveChangesAsync();
                            MessageBox.Show("Сотрудник успешно обновлён!");
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует!");
                        }
                    }
                }
            }
        }
    }
}

