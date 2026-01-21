using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace PRG1_MAUI_ERP_Activum.View {
    public partial class PerDiemPage : ContentPage
    {
        public PerDiemPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
    {
            if (StartDatePicker.Date == null || EndDatePicker.Date == null)
    {
        ResultLabel.Text = "Please select both start and end dates.";
        ResultLabel.TextColor = Colors.Red;
        return;
    }

    DateTime start = StartDatePicker.Date.Value;
    DateTime end = EndDatePicker.Date.Value;

    if (end < start)
    {
        ResultLabel.Text = "End date must be after start date.";
        ResultLabel.TextColor = Colors.Red;
        return;
    }

    int totalDays = (end - start).Days + 1;
    int perDiemPerDay = 240;
    int total = totalDays * perDiemPerDay;

    ResultLabel.TextColor = Colors.Green;
    ResultLabel.Text = $"Antal dagar: {totalDays} Traktamente per dag: {perDiemPerDay} SEK Totalt traktamente: {total} SEK";
}
    }
}



