using Seren.Resources.Strings;

namespace Seren.Scripts.Views;

public partial class SurveyPage : ContentPage
{
    private enum PageStep
    {
        None,
        YouHaveAttack,
        HowStrongIsAttack,
        Survey
    }

    private PageStep _currentStep = PageStep.None;

    public SurveyPage()
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
            case PageStep.Survey:
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
            RateLow.FadeTo(1, 2000),
            RateBelowAverage.FadeTo(1, 2000),
            RateAverage.FadeTo(1, 2000),
            RateAboveAverage.FadeTo(1, 2000),
            RateHigh.FadeTo(1, 2000),
        };
        
        await Task.WhenAll(tasks);
    }
    
    private void OnRateButtonClicked(object? sender, EventArgs e)
    {
        if (sender is RateButton button)
        {
            button.Choose();
        }
    }
    
    private async void OnBackClick(object? sender, EventArgs e) =>
        await Navigation.PopAsync();
}