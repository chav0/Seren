using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class MeditationRepository() : JsonRepository<Meditation>(MeditationJsonPath), IRepository<Meditation>
{
    private const string MeditationJsonPath = "meditations.json";
}