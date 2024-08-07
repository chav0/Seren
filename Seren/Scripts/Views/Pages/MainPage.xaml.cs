﻿using Plugin.Maui.Audio;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class MainPage 
{
	private readonly IPageFactory _pageFactory;
	
	private IAudioPlayer _player;

	public MainPage(MainPageViewModel viewModel, IPageFactory pageFactory, IAudioManager audioManager) : base(viewModel)
	{
		_pageFactory = pageFactory;
		
		InitializeBackgroundMusic(audioManager);
		InitializeComponent();
		InitializeCalendar();
		InitializeBreathingExercises();
		InitializeMeditations();
		NavigationPage.SetHasNavigationBar(this, false);
	}
	
	private async void InitializeBackgroundMusic(IAudioManager audioManager)
	{
		_player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("background_music.mp3"));
		_player.Loop = true;
		_player.Play();
	}
	
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
}


