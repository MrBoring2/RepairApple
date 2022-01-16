using AppleRepair.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Services
{
    public class UserService
    {
        private static UserService instance;
        private UserService() { }
        public static UserService Instance { get => instance ?? (instance = new UserService()); }
        public Employee CurrentUser { get; private set; }
        public void SetEmployee(Employee employee)
        {
            CurrentUser = employee;
        }
        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
