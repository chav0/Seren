using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IMeditationRepository
{
    Task<IEnumerable<Meditation>> GetAllAsync();
    Task<Meditation> GetByIdAsync(string meditationId);
}