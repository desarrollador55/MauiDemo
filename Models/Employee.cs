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
        public string EmployeeName { get; set; }
        public string Email { get; set; }

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
