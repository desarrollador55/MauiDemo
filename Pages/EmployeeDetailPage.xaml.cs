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
        EditPage employeeEditPage = new EditPage();
        employeeEditPage.BindingContext = BindingContext;
        await Navigation.PushAsync(employeeEditPage);
    }

    private async void Finalizar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}