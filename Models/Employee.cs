using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiMvvmDemo.Models
{
    internal partial class Employee : ObservableObject
    {
        private string _employeeId;
        private string _employeeName;
        private string _email;
        private bool _blocked;

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
        public bool Blocked{
            get => _blocked;
            set => SetProperty(ref _blocked, value);
        }

        public Employee()
        {
            
        }

        public Employee(string employeeId, string employeeName, string email, bool blocked)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            Email = email;
            Blocked = blocked;
        }
    }
}
