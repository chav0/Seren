using Plugin.Maui.Audio;
using Seren.Scripts.Models;
using Seren.Scripts.Repositories;
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
		var meditationRepository = serviceProvider.GetRequiredService<IRepository<Meditation>>();
		await meditationRepository.LoadItemsAsync();

		var questionaryRepository = serviceProvider.GetRequiredService<IRepository<PanicQuestion>>();
		await questionaryRepository.LoadItemsAsync();

		var breathingRepository = serviceProvider.GetRequiredService<IRepository<BreathingExercise>>();
		await breathingRepository.LoadItemsAsync();
		
		await Task.Delay(2000);
		MainPage = new InfoPage();
	}
}

