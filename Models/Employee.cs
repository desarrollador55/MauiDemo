using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiMvvmDemo.Models
{
    internal class Employee : ObservableObject
    {
        private string _employeeId;
        private string _employeeName;
        private string _email;

        public string EmployeeId {
            get => _employeeId;
            set => SetProperty(ref _employeeId, value);
        }
        public string EmployeeName {
            get => _employeeName;
            set => SetProperty(ref _employeeName, value);
        }
        public string Email {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public Employee()
        {
            
        }

        public Employee(string employeeId, string employeeName, string email)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.Email = email;
        }
    }
}
