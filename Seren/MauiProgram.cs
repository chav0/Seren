using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Seren.Scripts.Repositories;
using Seren.Scripts.Services;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Pages;
using Seren.Scripts.Views.Views;
using Plugin.Maui.Audio;
using Seren.Scripts.Views.Popups;

namespace Seren;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGroteskRegular");
				fonts.AddFont("Vollkorn-Bold.ttf", "VollkornBold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder
			.RegisterServices()
			.RegisterPages()
			.RegisterPopups()
			.RegisterViews()
			.RegisterAudio()
			.Build();
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		builder.Services
			.AddSingleton<IPageFactory, PageFactory>()
			.AddSingleton<IMeditationRepository, MeditationRepository>()
			.AddSingleton<IBreathingExerciseRepository, BreathingExerciseRepository>()
			.AddSingleton<IPanicQuestionaryRepository, PanicQuestionaryRepository>()
			.AddSingleton<IUserCalendarRepository, UserCalendarRepository>();

		return builder;        
	}

	private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransientWithShellRoute<MainPage, MainPageViewModel>("main")
			.AddTransientWithShellRoute<SurveyPage, SurveyPageViewModel>("main/survey")
			.AddTransientWithShellRoute<MeditationPage, MeditationViewModel>("main/meditation")
			.AddTransientWithShellRoute<SelfHelpPage, SelfHelpViewModel>("main/selfhelp")
			.AddTransientWithShellRoute<SettingsPage, SettingsViewModel>("main/settings")
			.AddTransient<CongratulationPage>();
		
		// TODO: create ViewModel
		Routing.RegisterRoute("practices/meditations", typeof(MeditationListPage));

		return builder;        
	}

	private static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransientPopup<DeleteDataPopup, DeleteDataViewModel>()
			.AddTransientPopup<ErrorPopup, ErrorPopupViewModel>();
		
		return builder;
	}
	
	private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services
			.AddTransient<CalendarView, CalendarViewModel>()
			.AddTransient<BreathingExercisesView, BreathingExercisesViewModel>()
			.AddTransient<MeditationsListView, MeditationsViewModel>();

		return builder;        
	}

	private static MauiAppBuilder RegisterAudio(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton(AudioManager.Current);
		mauiAppBuilder.Services.AddSingleton(provider =>
		{
			var audioManager = provider.GetRequiredService<IAudioManager>();
			var player = audioManager.CreatePlayer(FileSystem.OpenAppPackageFileAsync("background_music.mp3").Result);
			player.Loop = true;
			return player;
		});

		return mauiAppBuilder;
	}

}