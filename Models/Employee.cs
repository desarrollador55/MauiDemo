namespace MauiMvvmDemo.Models
{
    internal class Employee
    {
        public string EmployeeId { get; set; }
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
