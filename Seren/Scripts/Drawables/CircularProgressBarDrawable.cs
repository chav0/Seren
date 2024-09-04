namespace Seren.Scripts.Drawables;

public class CircularProgressBarDrawable : BindableObject, IDrawable
{
    public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(float), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty SectionsProperty = BindableProperty.Create(nameof(Sections), typeof(float[]), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarDrawable));
    public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarDrawable));

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

    public float[] Sections
    {
        get => (float[])GetValue(SectionsProperty);
        set => SetValue(SectionsProperty, value);
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

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var effectiveSize = Size - Thickness;
        var x = Thickness / 2f;
        var y = Thickness / 2f;

        Progress = Progress switch
        {
            < 0 => 0,
            > 100 => 100,
            _ => Progress
        };

        var angle = GetAngle(Progress);
        
        if (Sections == null || Sections.Length <= 1)
        {
            if (Progress < 100)
            {
                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
                
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, 90, angle, true, false);
            }
            else
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
            }
        }
        else
        {
            var sectionsSum = Sections.Sum();
            var progress = 0f;
            
            for (var i = 0; i < Sections.Length; i++)
            {
                var section = Sections[i];
                var progressFrom = 100 / sectionsSum * progress + 0.5f;
                progress += section;
                var progressTo = 100 / sectionsSum * progress - 0.5f;
            
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