using MauiMvvmDemo.Models.ViewModels;
using MauiMvvmDemo.Models;
using System.Xml.Linq;

namespace MauiMvvmDemo.Pages;

public partial class EditPage : ContentPage
{
	public EditPage()
	{
		InitializeComponent();
    }

    private async void Finalizar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}