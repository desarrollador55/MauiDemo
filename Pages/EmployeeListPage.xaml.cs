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

    private async void IniciarLista()
    {
        HttpClient cliente = new HttpClient();
        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        HttpResponseMessage response = await cliente.GetAsync("https://deb39002-6d81-485f-9ba9-2f73fc2a7127.mock.pstmn.io/MockMaui2");
        string json = await response.Content.ReadAsStringAsync();
        objetos = JsonSerializer.Deserialize<ObservableCollection<Employee>>(json, _serializerOptions);
        collectionView.ItemsSource = objetos;
    }

    private void Adicion_Clicked(object sender, EventArgs e)
    {
        Employee employee = new Employee(Id.Text, Name.Text, Email.Text, Blocked.IsToggled);
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
        Employee employee = (Employee) collectionView.SelectedItem;
		EmployeeDetailViewModel employeeDetailViewModel = new EmployeeDetailViewModel { Employee = employee };
		EmployeeDetailPage employeeDetailPage = new EmployeeDetailPage();
		employeeDetailPage.BindingContext = employeeDetailViewModel;
		await Navigation.PushAsync(employeeDetailPage);
    }

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        Employee employee = (Employee)collectionView.SelectedItem;

        if (employee.Blocked == true)
            return;
        objetos.Remove(employee);
    }
}