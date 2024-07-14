namespace Seren.Scripts.Drawables;

public class CircularProgressBarDrawable : BindableObject, IDrawable
{
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty SectionsCountProperty = BindableProperty.Create(nameof(SectionsCount), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarDrawable));

    public float Progress
    {
        get => (float)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }

    public int Size
    {
        get { return (int)GetValue(SizeProperty); }
        set { SetValue(SizeProperty, value); }
    }

    public int Thickness
    {
        get { return (int)GetValue(ThicknessProperty); }
        set { SetValue(ThicknessProperty, value); }
    }

    public int SectionsCount
    {
        get { return (int)GetValue(SectionsCountProperty); }
        set { SetValue(SectionsCountProperty, value); }
    }

    public Color ProgressColor
    {
        get { return (Color)GetValue(ProgressColorProperty); }
        set { SetValue(ProgressColorProperty, value); }
    }

    public Color ProgressLeftColor
    {
        get { return (Color)GetValue(ProgressLeftColorProperty); }
        set { SetValue(ProgressLeftColorProperty, value); }
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float effectiveSize = Size - Thickness;
        float x = Thickness / 2;
        float y = Thickness / 2;

        Progress = Progress switch
        {
            < 0 => 0,
            > 100 => 100,
            _ => Progress
        };

        var angle = GetAngle(Progress);
        var sectionProgress = 100 / SectionsCount;
        
        for (var i = 0; i < SectionsCount; i++)
        {
            var progressFrom = i * sectionProgress + 0.5f;
            var progressTo = (i + 1) * sectionProgress - 0.5f;

            if (i + 1 == SectionsCount)
                progressTo = 100 - 0.5f; 
            
            var angleFrom = GetAngle(progressFrom);
            var angleTo = GetAngle(progressTo);

            if (Progress < progressFrom)
            {
                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, angleFrom, angleTo, true, false);
            } 
            else if (Progress > progressTo)
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, angleFrom, angleTo, true, false);
            }
            else
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, angleFrom, angle, true, false);
                
                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, angle, angleTo, true, false);
            }
        }
    }

    private static float GetAngle(float progress)
    {
        const float factor = 90f / 25f;

        return progress switch
        {
            > 75 => -180 - (progress - 75) * factor,
            > 50 => -90 - (progress - 50) * factor,
            > 25 => 0 - (progress - 25) * factor,
            _ => 90 - progress * factor
        };
    }
}