using System.Windows.Input;
using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Pages;

namespace Seren.Scripts.Views.Views;

public partial class BreathingExerciseCardView : BaseView<BreathingExerciseViewModel>
{
    public BreathingExerciseCardView(BreathingExerciseViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        
        
    }

    private async void OnTapped(object? sender, EventArgs eventArgs) => 
        await Application.Current.MainPage.Navigation.PushAsync(new BreathingExercisePage(BindingContext));
}