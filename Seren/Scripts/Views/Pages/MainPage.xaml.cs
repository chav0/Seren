namespace Seren.Scripts.Views.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}

	private async void OnPanicClick(object sender, EventArgs eventArgs)
	{
		var surveyPage = IPlatformApplication.Current?.Services.GetService<SurveyPage>();
		await Navigation.PushAsync(surveyPage);
	}

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


