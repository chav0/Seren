using Seren.Scripts.ViewModels;
using Seren.Scripts.Views.Pages;

namespace Seren.Scripts.Views.Views;

public partial class MeditationCardView : BaseView<MeditationViewModel>
{
    public MeditationCardView(MeditationViewModel viewModel) : base(viewModel) => 
        InitializeComponent();

    private async void OnTapped(object? sender, TappedEventArgs e) => 
        await Application.Current.MainPage.Navigation.PushAsync(new MeditationPage(BindingContext));
}