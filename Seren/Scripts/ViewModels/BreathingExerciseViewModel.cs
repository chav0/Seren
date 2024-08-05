using Seren.Scripts.Models;

namespace Seren.Scripts.ViewModels;

public class BreathingExerciseViewModel(BreathingExercise breathingExercise) : BaseViewModel
{
    public string Header => breathingExercise.Header;

    public string FullImagePath => breathingExercise.FullImagePath;

    public int TimeSeconds => (int) breathingExercise.Patterns.Sum(x => x.Time) * breathingExercise.Count;
    
    public string TimeText
    {
        get
        {
            var time = TimeSpan.FromSeconds(TimeSeconds);
            if (time.Minutes > 0)
                return $"{time.Minutes}m {time.Seconds}s";
            
            return $"{time.TotalSeconds}s";
        }
    }

    public int BreathingCount => breathingExercise.Count;

    public int PatternCount => breathingExercise.Patterns.Count;

    public List<BreathingPatternEntry> Patterns => breathingExercise.Patterns;

    public float CurrentProgress { get; private set; }
    public int CurrentPatternRemainingTime { get; private set; }
    public string CurrentPatternType { get; private set; }

    public void UpdateTimer(float remainingTime)
    {
        var time = TimeSeconds - remainingTime;
        var circleTime = TimeSeconds / (float) BreathingCount;
        var currentTimeInCircle = time % circleTime;

        CurrentProgress = currentTimeInCircle / circleTime;
        
        OnPropertyChanged();
        OnPropertyChanged(nameof(CurrentProgress));

        foreach (var pattern in Patterns)
        {
            currentTimeInCircle -= pattern.Time;
            if (currentTimeInCircle < 0)
            {
                CurrentPatternRemainingTime = (int) -currentTimeInCircle;
                CurrentPatternType = pattern.Type.ToString();
                
                OnPropertyChanged(nameof(CurrentPatternRemainingTime));
                OnPropertyChanged(nameof(CurrentPatternType));
                break;
            }
        }
    }
}