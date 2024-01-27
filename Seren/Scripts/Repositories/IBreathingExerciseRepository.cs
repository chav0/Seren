using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IBreathingExerciseRepository
{
    Task<IEnumerable<BreathingExercise>> GetAllAsync();
    Task<BreathingExercise> GetByIdAsync(string meditationId);
}