using Plugin.Maui.Audio;
using Seren.Scripts.Views.Pages;

namespace Seren;

public partial class App : Application
{
	public static IServiceProvider Services { get; private set; }
	
	public App(IServiceProvider serviceProvider)
	{
		Services = serviceProvider;
		InitializeComponent();
		MainPage = new LoadingPage();
		InitializeAsync(serviceProvider);
	}

	private async void InitializeAsync(IServiceProvider serviceProvider)
	{
		await Task.Delay(3000);
		MainPage = new InfoPage();
	}
}

