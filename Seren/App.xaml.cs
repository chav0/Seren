using Seren.Screens;
using Seren.Scripts.Services;

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
		await serviceProvider.GetService<ILocalizationService>().InitializeAsync();
		
		//MainPage = new MainPage();
	}
}

