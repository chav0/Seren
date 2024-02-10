using Seren.Screens;

namespace Seren;

public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		MainPage = new LoadingPage();
		InitializeAsync(serviceProvider);
	}

	private async void InitializeAsync(IServiceProvider serviceProvider)
	{
		await Task.Delay(5000);
		
		MainPage = new MainPage();
	}
}

