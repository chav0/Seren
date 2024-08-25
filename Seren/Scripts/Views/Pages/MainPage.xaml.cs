using Plugin.Maui.Audio;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class MainPage 
{
	private readonly IPageFactory _pageFactory;
	
	public MainPage(MainPageViewModel viewModel, IPageFactory pageFactory, IAudioPlayer player) : base(viewModel)
	{
		_pageFactory = pageFactory;
		
		InitializeBackgroundMusic(player);
		InitializeComponent();
		InitializeCalendar();
		InitializeBreathingExercises();
		InitializeMeditations();
		NavigationPage.SetHasNavigationBar(this, false);
	}
	
	private void InitializeBackgroundMusic(IAudioPlayer player) => player.Play();

	private void InitializeCalendar()
	{
		var calendarViewModel = _pageFactory.GetViewModel<CalendarViewModel>();
		var calendarView = new CalendarView(calendarViewModel);
		CalendarContainer.Content = calendarView;
	}
	
	private void InitializeBreathingExercises()
	{
		var breathingExercisesViewModel = _pageFactory.GetViewModel<BreathingExercisesViewModel>();
		var breathingExercisesView = new BreathingExercisesView(breathingExercisesViewModel);
		BreathingExercisesContainer.Content = breathingExercisesView;
	}
	
	private void InitializeMeditations()
	{
		var meditationsViewModel = _pageFactory.GetViewModel<MeditationsViewModel>();
		var meditationsListView = new MeditationsListView(meditationsViewModel);
		MeditationsContainer.Content = meditationsListView;
	}
 
	private async void OnPanicClick(object sender, EventArgs eventArgs)
	{
		var surveyPage = App.Services.GetService<SelfHelpPage>();
		await Navigation.PushAsync(surveyPage);
	}
	
	private async void OnSettingsClick(object sender, EventArgs eventArgs)
	{
		var surveyPage = App.Services.GetService<SettingsPage>();
		await Navigation.PushAsync(surveyPage);
	}
}


