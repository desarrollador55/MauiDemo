using MauiMvvmDemo.Models;
using MauiMvvmDemo.Models.ViewModels;

namespace MauiMvvmDemo.Pages;

public partial class EmployeeDetailPage : ContentPage
{
	public EmployeeDetailPage()
	{
		InitializeComponent();
	}

    private async void EditDetail_Clicked(object sender, EventArgs e)
    {
        var employee = new Employee(Id.Detail,Name.Detail,Email.Detail);
        var employeeDetailViewModel = new EmployeeDetailViewModel { Employee = employee };
        var employeeEditPage = new EditPage();
        employeeEditPage.BindingContext = employeeDetailViewModel;
        await Navigation.PushAsync(employeeEditPage);
    }

    private async void Finalizar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}