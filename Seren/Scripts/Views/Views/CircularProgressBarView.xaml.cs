namespace Seren.Scripts.Views.Views;

public partial class CircularProgressBarView
{
    public CircularProgressBarView()
    {
        InitializeComponent();
    }
    
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty SectionsCountProperty = BindableProperty.Create(nameof(SectionsCount), typeof(int), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);
    public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarView), propertyChanged: OnBindablePropertyChanged);

    public float Progress
    {
        get => (float)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public int Size
    {
        get => (int)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    public int Thickness
    {
        get => (int)GetValue(ThicknessProperty);
        set => SetValue(ThicknessProperty, value);
    }
    
    public int SectionsCount
    {
        get { return (int)GetValue(SectionsCountProperty); }
        set { SetValue(SectionsCountProperty, value); }
    }

    public Color ProgressColor
    {
        get => (Color)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public Color ProgressLeftColor
    {
        get => (Color)GetValue(ProgressLeftColorProperty);
        set => SetValue(ProgressLeftColorProperty, value);
    }

    protected override void OnPropertyChanged(string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == SizeProperty.PropertyName)
        {
            HeightRequest = Size;
            WidthRequest = Size;
        }
    }

    private static void OnBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (CircularProgressBarView)bindable;
        control.UpdateDrawable();
    }

    private void UpdateDrawable()
    {
        if (Drawable != null)
        {
            Drawable.Progress = Progress;
            Drawable.Size = Size;
            Drawable.Thickness = Thickness;
            Drawable.SectionsCount = SectionsCount;
            Drawable.ProgressColor = ProgressColor;
            Drawable.ProgressLeftColor = ProgressLeftColor;
            GraphicsView.Invalidate();
        }
    }
}