using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Views;

namespace Seren.Scripts.Views.Pages;

public partial class BreathingExercisePage : BasePage<BreathingExerciseViewModel>
{
    public BreathingExercisePage(BreathingExerciseViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        InitializeTimer(); 
    }
    
    private void InitializeTimer()
    {
        var timerViewModel = new TimerViewModel(TimeSpan.FromSeconds(BindingContext.TimeSeconds)); 
        var timerView = new TimerView(timerViewModel);
        Timer.Content = timerView;
    }
}