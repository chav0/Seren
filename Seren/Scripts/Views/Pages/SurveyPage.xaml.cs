using Seren.Resources.Strings;
using Seren.Scripts.ViewModels;

namespace Seren.Scripts.Views.Pages;

public partial class SurveyPage
{
    private PageStep _currentStep = PageStep.None;
    
    public SurveyPage(SurveyPageViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
        SwitchToNextStep();
    }

    private void SwitchToNextStep()
    {
        switch (++_currentStep)
        {
            case PageStep.YouHaveAttack:
                SetText(Localizations.YouHavePanic);
                break;
            case PageStep.HowStrongIsAttack:
                SetText(Localizations.HowStrongIsAttack);
                break;
            case PageStep.Choose:
                MoveLabelUp();
                break;
        }
    }
    
    private async void SetText(string text)
    {
        AnimatedLabel.Opacity = 0;
        AnimatedLabel.Text = text;
        await AnimatedLabel.FadeTo(1, 2000);
        await Task.Delay(2000);
        SwitchToNextStep();
    }

    private async Task MoveLabelUp()
    {
        await AnimatedLabel.TranslateTo(0, -Height * 0.3, 1000, Easing.CubicOut);
        await InitializeRateButtons();
    }

    private async Task InitializeRateButtons()
    {
        var tasks = new List<Task>
        {
            RateNone.FadeTo(1, 2000),
            RateMild.FadeTo(1, 2000),
            RateModerate.FadeTo(1, 2000),
            RateSevere.FadeTo(1, 2000),
            RateExtreme.FadeTo(1, 2000),
        };
        
        await Task.WhenAll(tasks);
    }
    
    private async void OnRateButtonClicked(object? sender, EventArgs e)
    {
        if (sender is not RateButton button || _currentStep == PageStep.Chosen) 
            return;
        
        var animationTask = button.Choose();
        var saveResultTask = BindingContext.SaveResult(button.PanicAttackLevel);
        await Task.WhenAll(animationTask, saveResultTask);
        await Navigation.PushAsync(new MeditationPage());
    }
    
    private async void OnBackClick(object? sender, EventArgs e) =>
        await Navigation.PopToRootAsync();
    
    private enum PageStep
    {
        None,
        YouHaveAttack,
        HowStrongIsAttack,
        Choose,
        Chosen
    }
}