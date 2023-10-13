using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiMvvmDemo.Models.ViewModels
{
    internal partial class EmployeeDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Employee employee;
    }
}
