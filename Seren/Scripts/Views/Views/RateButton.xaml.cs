using Seren.Scripts.Models;

namespace Seren.Scripts.Views.Views;

public partial class RateButton : ContentView
{
    public RateButton()
    {
        InitializeComponent();
        BindingContext = this;
    }
        
    public static readonly BindableProperty ButtonColorProperty =
        BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(RateButton));

    public Color ButtonColor
    {
        get => (Color)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }
    
    public static readonly BindableProperty PanicAttackLevelProperty =
        BindableProperty.Create(nameof(MoodText), typeof(PanicAttackLevel), typeof(RateButton));
    
    public PanicAttackLevel PanicAttackLevel
    {
        get => (PanicAttackLevel)GetValue(PanicAttackLevelProperty);
        set => SetValue(PanicAttackLevelProperty, value);
    }
    
    public static readonly BindableProperty MoodTextProperty =
        BindableProperty.Create(nameof(MoodText), typeof(string), typeof(RateButton));
    
    public string MoodText
    {
        get => (string)GetValue(MoodTextProperty);
        set => SetValue(MoodTextProperty, value);
    }

    public event EventHandler? Clicked;
    private void OnInternalButtonClicked(object sender, EventArgs e) => 
        Clicked?.Invoke(this, e);
    
    public Task FadeTo(double opacity, uint length) => InnerButton.FadeTo(opacity, length);

    public Task Choose()
    {
        return Task.WhenAll(
            InnerButton.ScaleTo(1.2, 1000, Easing.CubicOut),
            InnerText.FadeTo(1, 1000));
    }
}