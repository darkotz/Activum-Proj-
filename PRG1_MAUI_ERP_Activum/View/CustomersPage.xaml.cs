namespace PRG1_MAUI_ERP_Activum.View;
using PRG1_MAUI_ERP_Activum.Model;
using PRG1_MAUI_ERP_Activum.Services;



public partial class CustomersPage : ContentPage
{
	public CustomersPage()
	{
		InitializeComponent();

        CustomersCollection.ItemsSource = RegisterService.Instance.Customers;
    }

    private void OnAddCustomerClicked(object sender, EventArgs e)
    {
        var customer = new Customer("John", "Doe", "john@mail.com", "123456");
        RegisterService.Instance.AddCustomer(customer);
    }

    private void OnDeleteCustomerClicked(object sender, EventArgs e)
    {
        if (CustomersCollection.SelectedItem is Customer selected)
        {
            RegisterService.Instance.RemoveCustomer(selected);
        }
    }

    private async void OnShowInsurancesClicked(object sender, EventArgs e)
    {
        if (CustomersCollection.SelectedItem is Customer selected)
        {
            var insurances = RegisterService.Instance
                .GetInsurancesForCustomer(selected);

            string message = string.Join("\n",
                insurances.Select(i => i.InsuranceType));

            await DisplayAlert("Customer Insurances", message, "OK");
        }
    }
}