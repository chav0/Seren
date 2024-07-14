namespace Seren.Scripts.Drawables;

public class CircularProgressBarDrawable : BindableObject, IDrawable
    {
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(int), typeof(CircularProgressBarDrawable));
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarDrawable));
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarDrawable));
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarDrawable));
        public static readonly BindableProperty ProgressLeftColorProperty = BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarDrawable));

        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
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

            if (Progress < 100)
            {
                var angle = GetAngle(Progress);

                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);

                // Draw arc
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, 90, angle, true, false);
            }
            else
            {
                // Draw circle
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
            }
        }

        private float GetAngle(int progress)
        {
            var factor = 90f / 25f;

            if (progress > 75)
            {
                return -180 - ((progress - 75) * factor);
            }
            else if (progress > 50)
            {
                return -90 - ((progress - 50) * factor);
            }
            else if (progress > 25)
            {
                return 0 - ((progress - 25) * factor);
            }
            else
            {
                return 90 - (progress * factor);
            }
        }
    }