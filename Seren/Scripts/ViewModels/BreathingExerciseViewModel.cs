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
}
