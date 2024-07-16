using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IPanicQuestionaryRepository
{
    Task<IEnumerable<PanicQuestion>> GetAllAsync();
    Task<PanicQuestion> GetByIdAsync(string meditationId);
}