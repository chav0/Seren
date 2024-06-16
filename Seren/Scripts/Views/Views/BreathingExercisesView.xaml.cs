using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Views;

public partial class BreathingExercisesView : BaseView<BreathingExercisesViewModel>
{
    public BreathingExercisesView(BreathingExercisesViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        LoadBreathingExercises();
    }

    private async void LoadBreathingExercises()
    {
        await BindingContext.LoadBreathingExercisesAsync();
        AddBreathingExerciseCards();
    }

    private void AddBreathingExerciseCards()
    {
        BreathingExercisesContainer.Children.Clear();

        foreach (var breathingExerciseViewModel in BindingContext.BreathingExercises)
        {
            var breathingExerciseCardView = new BreathingExerciseCardView(breathingExerciseViewModel);
            BreathingExercisesContainer.Children.Add(breathingExerciseCardView);
        }
    }
}