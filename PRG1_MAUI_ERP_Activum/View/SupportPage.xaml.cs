namespace PRG1_MAUI_ERP_Activum.View;

public partial class SupportPage : ContentPage
{
    public SupportPage()
    {
        InitializeComponent();
    }



    private void OnQuestionTapped(object sender, EventArgs e)
    {
        var label = sender as Label;

        var answer = label.BindingContext as Label;

        answer.IsVisible = !answer.IsVisible;

    }

    private void OnShowOpeningHours(object sender, EventArgs e)

    {

    }
}