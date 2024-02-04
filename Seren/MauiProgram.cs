using Microsoft.Extensions.Logging;
using Seren.Scripts.Repositories;
using Seren.Scripts.Services;

namespace Seren;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGroteskRegular");
				//fonts.AddFont("Vollkorn-Bold.ttf", "VollkornBold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		builder.Services
			// models
			// repository
			.AddSingleton<IMeditationRepository, MeditationRepository>()
			.AddSingleton<IBreathingExerciseRepository, BreathingExerciseRepository>()
			.AddSingleton<IUserMoodCalendarRepository, UserMoodCalendarRepository>()
			// services
			.AddSingleton<ILocalizationService, LocalizationService>();

		return builder.Build();
	}
}

