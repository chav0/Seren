namespace Seren.Scripts.Views;

public partial class MainMenuButtonView : ContentView
{
    public event EventHandler Clicked;
    
    public MainMenuButtonView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnInternalButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, e);
    }
    
    public static readonly BindableProperty HeaderProperty =
        BindableProperty.Create(nameof(Header), typeof(string), typeof(MainMenuButtonView));
    
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(MainMenuButtonView));
    
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }
    
    public static readonly BindableProperty IconPathProperty = 
        BindableProperty.Create(nameof(IconPath), typeof(string), typeof(MainMenuButtonView));
    
    public string IconPath
    {
        get => (string)GetValue(IconPathProperty);
        set => SetValue(IconPathProperty, value);
    }
    
    public static readonly BindableProperty ColorProperty = 
        BindableProperty.Create(nameof(Color), typeof(Color), typeof(MainMenuButtonView));
    
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
    
    public static readonly BindableProperty TextColorProperty = 
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MainMenuButtonView));
    
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }
}