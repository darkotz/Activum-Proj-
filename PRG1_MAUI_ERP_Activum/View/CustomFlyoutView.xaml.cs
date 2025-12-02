using System.Diagnostics;
using System.Windows.Input;

namespace PRG1_MAUI_ERP_Activum.View;

public partial class CustomFlyoutView : ContentView
{
    public ICommand NavigateCommand { get; }
    public ICommand ToggleToolsCommand { get; }

    public CustomFlyoutView()
    {
        NavigateCommand = new Command<string>(async (page) =>
        {
            Debug.WriteLine($"[CustomFlyoutView] NavigateCommand: {page}");
            await Shell.Current.GoToAsync($"//{page}");
            Shell.Current.FlyoutIsPresented = false;
        });

        ToggleToolsCommand = new Command(() =>
        {
            Debug.WriteLine("[CustomFlyoutView] ToggleToolsCommand executed");
            ToolsSubMenu.IsVisible = !ToolsSubMenu.IsVisible;
        });

        InitializeComponent();

        BindingContext = this;
    }
}

