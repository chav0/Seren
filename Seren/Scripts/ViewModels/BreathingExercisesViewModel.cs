using System.Collections.ObjectModel;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.ViewModels;

public class BreathingExercisesViewModel : BaseViewModel
{
    private readonly IBreathingExerciseRepository _breathingExerciseRepository;

    public ObservableCollection<BreathingExerciseViewModel> BreathingExercises { get; set; }

    public BreathingExercisesViewModel(IBreathingExerciseRepository breathingExerciseRepository)
    {
        _breathingExerciseRepository = breathingExerciseRepository;
        BreathingExercises = new ObservableCollection<BreathingExerciseViewModel>();
    }

    public async Task LoadBreathingExercisesAsync()
    {
        var exercises = await _breathingExerciseRepository.GetAllAsync();
        BreathingExercises.Clear();
        foreach (var exercise in exercises)
        {
            BreathingExercises.Add(new BreathingExerciseViewModel(exercise));
        }
    }
}