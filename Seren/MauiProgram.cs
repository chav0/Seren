using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Seren.Scripts.Repositories;
using Seren.Scripts.Services;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Pages;
using Seren.Scripts.Views.Views;
using Plugin.Maui.Audio;

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
			.RegisterViews()
			.Build();
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddSingleton(AudioManager.Current)
			.AddSingleton<IPageFactory, PageFactory>()
			.AddSingleton<IMeditationRepository, MeditationRepository>()
			.AddSingleton<IBreathingExerciseRepository, BreathingExerciseRepository>()
			.AddSingleton<IPanicQuestionaryRepository, PanicQuestionaryRepository>()
			.AddSingleton<IUserCalendarRepository, UserCalendarRepository>();

		return mauiAppBuilder;        
	}

	private static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddTransientWithShellRoute<MainPage, MainPageViewModel>("main")
			.AddTransientWithShellRoute<SurveyPage, SurveyPageViewModel>("main/survey")
			.AddTransientWithShellRoute<MeditationPage, MeditationViewModel>("main/meditation")
			.AddTransientWithShellRoute<SelfHelpPage, SelfHelpViewModel>("main/selfhelp")
			.AddTransient<CongratulationPage>();
		
		// TODO: create ViewModel
		Routing.RegisterRoute("practices/meditations", typeof(MeditationListPage));

		return mauiAppBuilder;        
	}
	
	private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddTransient<CalendarView, CalendarViewModel>()
			.AddTransient<BreathingExercisesView, BreathingExercisesViewModel>()
			.AddTransient<MeditationsListView, MeditationsViewModel>();

		return mauiAppBuilder;        
	}
}