using MauiMvvmDemo.Models.ViewModels;

namespace MauiMvvmDemo.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void CapturarPedidos_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmployeeListPage());
    }
}