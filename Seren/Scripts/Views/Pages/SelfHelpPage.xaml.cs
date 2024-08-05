using System.ComponentModel;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public partial class SelfHelpPage
{
    public SelfHelpPage(SelfHelpViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        viewModel.PropertyChanged += CheckTheEnd;
    }

    private async void CheckTheEnd(object? sender, PropertyChangedEventArgs e)
    {
        if (BindingContext.PanicQuestions.Count == BindingContext.CurrentQuestionIndex)
        {
            var congratulationPage = App.Services.GetService<CongratulationPage>();
            await Navigation.PushAsync(congratulationPage);
        }
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        BindingContext.PropertyChanged -= CheckTheEnd;
    }
}