using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Seren.Scripts.Repositories;
using Seren.Scripts.Services;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views;
using Seren.Scripts.Views.Pages;

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

		return builder.RegisterServices()
			.RegisterViewModels()
			.RegisterViews()
			.Build();
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddSingleton<IMeditationRepository, MeditationRepository>()
			.AddSingleton<IBreathingExerciseRepository, BreathingExerciseRepository>()
			.AddSingleton<IUserCalendarRepository, UserCalendarRepository>();

		return mauiAppBuilder;        
	}

	private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddTransient<SurveyPage, SurveyPageViewModel>();
		mauiAppBuilder.Services.
			AddTransient<SurveyPageViewModel>();

		return mauiAppBuilder;        
	}

	private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services
			.AddTransient<SurveyPage>();

		return mauiAppBuilder;        
	}
}

