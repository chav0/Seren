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
        var timerView = new TimerView(_timerViewModel);
        Timer.Content = timerView;
    }
}