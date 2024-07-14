using System.ComponentModel;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class BreathingExercisePage
{
    private TimerViewModel _timerViewModel;

    public BreathingExercisePage(BreathingExerciseViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        InitializeNavigationBar();
        InitializeTimer();
    }

    private void InitializeNavigationBar()
    {
        var navigationBar = new NavigationBar
        {
            TitleText = BindingContext.Header
        };

        NavigationBar.Content = navigationBar;
    }

    private void InitializeTimer()
    {
        _timerViewModel = new TimerViewModel(TimeSpan.FromSeconds(BindingContext.TimeSeconds));
        _timerViewModel.PropertyChanged += OnTimerTicked;

        var timerView = new TimerView(_timerViewModel);
        Timer.Content = timerView;
    }

    private void OnTimerTicked(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        BindingContext.UpdateTimer((float)_timerViewModel.RemainingTime.TotalSeconds);
        ProgressBar.Progress = BindingContext.CurrentProgress;
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        DisposeTimerViewModel();
    }

    private void DisposeTimerViewModel()
    {
        _timerViewModel.PropertyChanged -= OnTimerTicked;
        _timerViewModel.Dispose();
    }
}