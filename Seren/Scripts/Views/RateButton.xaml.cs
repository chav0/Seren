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
    public string RateText { get; set; }

    public event EventHandler? Clicked;
    private void OnInternalButtonClicked(object sender, EventArgs e) => 
        Clicked?.Invoke(this, e);
    
    public Task FadeTo(double opacity, uint length) => InnerButton.FadeTo(opacity, length);
}