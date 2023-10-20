using MauiMvvmDemo.Models;
using MauiMvvmDemo.Models.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MauiMvvmDemo.Pages;

public partial class EmployeeListPage : ContentPage
{
    ObservableCollection<Employee> objetos;

    public EmployeeListPage()
	{
		InitializeComponent();

        IniciarLista();
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var employee = (Employee)e.Item;
		var employeeDetailViewModel = new EmployeeDetailViewModel { Employee = employee };
		var employeeDetailPage = new EmployeeDetailPage();
		employeeDetailPage.BindingContext = employeeDetailViewModel;
		await Navigation.PushAsync(employeeDetailPage);
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
        objetos = JsonSerializer.Deserialize<ObservableCollection<Employee>>(json, _serializerOptions);
        collectionView.ItemsSource = objetos;
    }

    private void Adicion_Clicked(object sender, EventArgs e)
    {
        Employee employee = new Employee(Id.Text, Name.Text, Email.Text);
        objetos.Add(employee);
    }

    private async void Terminar_Clicked(object sender, EventArgs e)
    {
        var employee = (ObservableCollection<Employee>) collectionView.ItemsSource;
        var employeesViewModel = new EmployeesViewModel { Employees = employee };
        var listaView = new ListViewPage();
        listaView.BindingContext = employeesViewModel;
        await Navigation.PushAsync(listaView);
    }

    private async void Detalles_Clicked(object sender, EventArgs e)
    {
        var employee = (Employee) collectionView.SelectedItem;
		var employeeDetailViewModel = new EmployeeDetailViewModel { Employee = employee };
		var employeeDetailPage = new EmployeeDetailPage();
		employeeDetailPage.BindingContext = employeeDetailViewModel;
		await Navigation.PushAsync(employeeDetailPage);
    }

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        var employee = (Employee)collectionView.SelectedItem;
        objetos.Remove(employee);
    }
}