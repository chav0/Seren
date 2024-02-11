namespace Seren.Scripts.Views;

public partial class MainMenuButtonView : ContentView
{
    public event EventHandler Clicked;
    
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(MainMenuButtonView), propertyChanged: OnTextChanged);
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public MainMenuButtonView()
    {
        InitializeComponent();
        InternalButton.Clicked += OnInternalButtonClicked;
    }

    private void OnInternalButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }

    private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (MainMenuButtonView)bindable;
        if (control != null)
        {
            control.InternalButton.Text = (string)newValue;
        }
    }
}