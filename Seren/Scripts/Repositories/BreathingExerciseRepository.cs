using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class BreathingExerciseRepository : JsonRepository<BreathingExercise>, IRepository<BreathingExercise>
{
    private const string BreathingExercisesJsonPath = "breathings.json";
    
    public BreathingExerciseRepository() : base(BreathingExercisesJsonPath)
    {
    }
}