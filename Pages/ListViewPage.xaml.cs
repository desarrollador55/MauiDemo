using MauiMvvmDemo.Models;
using MauiMvvmDemo.Models.ViewModels;
using System.Text.Json;

namespace MauiMvvmDemo.Pages;

public partial class ListViewPage : ContentPage
{
	public ListViewPage()
	{
		InitializeComponent();

        BindingContext = new EmployeesViewModel();
        //IniciarLista();
    }

    private async void Finalizar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void IniciarLista()
    {
        HttpClient cliente = new HttpClient();
        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        HttpResponseMessage response = await cliente.GetAsync("https://6340d5f6-4ea8-4aa6-9019-262d4f14bda6.mock.pstmn.io/pruebaMaui");
        string json = await response.Content.ReadAsStringAsync();
        List<Employee> objetos = JsonSerializer.Deserialize<List<Employee>>(json, _serializerOptions);
        listView.ItemsSource = objetos;
    }
}