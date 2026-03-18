using PRG1_MAUI_ERP_Activum.Model;
using PRG1_MAUI_ERP_Activum.Services;

namespace PRG1_MAUI_ERP_Activum.View;

public partial class AddCustomerPopup : ContentPage
{
	public AddCustomerPopup()
	{
		InitializeComponent();
	}
	private async void OnSaveClicked(object sender, EventArgs e)
	{
		var customer = new Customer(
			FirstNameEntry.Text,
			LastNameEntry.Text,
			EmailEntry.Text,
			PhoneEntry.Text
			);

		RegisterService.Instance.AddCustomer(customer);

        if (SjukCheck.IsChecked)
        {
            var ins = RegisterService.Instance.GetOrCreateInsurance("Sjuk");
            RegisterService.Instance.LinkInsurance(customer, ins);
        }

        if (BilCheck.IsChecked)
        {
            var ins = RegisterService.Instance.GetOrCreateInsurance("Bil");
            RegisterService.Instance.LinkInsurance(customer, ins);
        }

        if (PetCheck.IsChecked)
        {
            var ins = RegisterService.Instance.GetOrCreateInsurance("Husdjur");
            RegisterService.Instance.LinkInsurance(customer, ins);
        }

        await Navigation.PopModalAsync();
    }
}