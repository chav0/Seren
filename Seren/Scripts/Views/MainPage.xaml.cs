namespace Seren.Scripts.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnPanicClick(object sender, EventArgs eventArgs) => 
		await Navigation.PushAsync(new SurveyPage());

	private void OnMeditationClick(object sender, EventArgs eventArgs)
	{
		
	}
	
	private void OnHelpClick(object sender, EventArgs eventArgs)
	{
		
	}
	
	private void OnBreathingClick(object sender, EventArgs eventArgs)
	{
		
	}
}


