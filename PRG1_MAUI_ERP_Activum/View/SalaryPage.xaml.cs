namespace PRG1_MAUI_ERP_Activum.View;

public partial class SalaryPage : ContentPage
{
    public SalaryPage()
    {
        InitializeComponent();
    }

    private void OnCalculateSalaryClicked(object sender, EventArgs e)
    {
        decimal grundlon = 26000;
        decimal provisionProcent = 0.12m;
        decimal skattProcent = 0.32m;

        if (SalesEntry.Text == "")
        {
            DisplayAlert("Fel", "Fyll i försäljning", "OK");
            return;
        }

        decimal forsäljning = decimal.Parse(SalesEntry.Text);

        decimal provision = forsäljning * provisionProcent;
        decimal bruttolon = grundlon + provision;
        decimal skatt = bruttolon * skattProcent;
        decimal nettolon = bruttolon - skatt;

        decimal summa = bruttolon;
        int antalManader = 1;

        if (PreviousSalariesEntry.Text != "")
        {
            string[] loner = PreviousSalariesEntry.Text.Split(',');

            for (int i = 0; i < loner.Length && antalManader < 12; i++)
            {
                decimal gammalLon = decimal.Parse(loner[i]);
                summa = summa + gammalLon;
                antalManader = antalManader + 1;
            }
        }

        decimal semesterlon = summa / antalManader;

        ProvisionLabel.Text = "Provision: " + provision + " kr";
        GrossSalaryLabel.Text = "Bruttolön: " + bruttolon + " kr";
        TaxLabel.Text = "Skatt: " + skatt + " kr";
        NetSalaryLabel.Text = "Nettolön: " + nettolon + " kr";
        VacationPayLabel.Text = "Semesterlön (snitt): " + semesterlon + " kr";
    }
}
