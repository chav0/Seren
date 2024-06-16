using Seren.Scripts.Models;

namespace Seren.Scripts.ViewModels;

public class BreathingExerciseViewModel(BreathingExercise breathingExercise) : BaseViewModel
{
    public string Header => breathingExercise.Header;

    public string FullImagePath => breathingExercise.FullImagePath;
    
    public string Time
    {
        get
        {

            var time = TimeSpan.FromSeconds(breathingExercise.Patterns.Sum(x => x.Time) * breathingExercise.Count);
            if (time.Minutes > 0)
                return $"{time.Minutes}m {time.Seconds}s";
            
            return $"{time.TotalSeconds}s";
        }
    }
}
