using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Views;

public partial class MeditationsListView : BaseView<MeditationsViewModel>
{
    public MeditationsListView(MeditationsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        LoadMeditations();
    }

    private async void LoadMeditations()
    {
        await BindingContext.LoadMeditationsAsync();
        AddMeditationsCards();
    }

    private void AddMeditationsCards()
    {
        MeditationsContainer.Children.Clear();

        foreach (var breathingExerciseViewModel in BindingContext.Meditations)
        {
            var breathingExerciseCardView = new MeditationCardView(breathingExerciseViewModel);
            MeditationsContainer.Children.Add(breathingExerciseCardView);
        }
    }
}