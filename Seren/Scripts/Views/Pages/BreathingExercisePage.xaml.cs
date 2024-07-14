using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class BreathingExercisePage
{
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
        var timerViewModel = new TimerViewModel(TimeSpan.FromSeconds(BindingContext.TimeSeconds)); 
        var timerView = new TimerView(timerViewModel);
        Timer.Content = timerView;
    }
}