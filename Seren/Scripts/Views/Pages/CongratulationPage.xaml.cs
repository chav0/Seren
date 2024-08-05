namespace Seren.Scripts.Views.Pages;

public partial class CongratulationPage
{
    public CongratulationPage()
    {
        InitializeComponent();
    }

    private async void OnPageTapped(object? sender, TappedEventArgs e) => 
        await Navigation.PopToRootAsync(true);
}