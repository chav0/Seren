namespace Seren.Scripts.Views;

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
    
    public int Rate { get; set; }
    
    public static readonly BindableProperty RateTextProperty =
        BindableProperty.Create(nameof(RateText), typeof(string), typeof(RateButton));
    
    public string RateText
    {
        get => (string)GetValue(RateTextProperty);
        set => SetValue(RateTextProperty, value);
    }

    public event EventHandler? Clicked;
    private void OnInternalButtonClicked(object sender, EventArgs e) => 
        Clicked?.Invoke(this, e);
    
    public Task FadeTo(double opacity, uint length) => InnerButton.FadeTo(opacity, length);

    public Task Choose()
    {
        return InnerButton.ScaleTo(1.2, 1000, Easing.CubicOut);
    }
}