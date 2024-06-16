using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public partial class BreathingExercisePage : BasePage<BreathingExerciseViewModel>
{
    public BreathingExercisePage(BreathingExerciseViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}