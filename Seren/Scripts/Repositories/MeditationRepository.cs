using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class MeditationRepository() : JsonRepository<Meditation>(MeditationJsonPath), IMeditationRepository
{
    private const string MeditationJsonPath = "meditations.json";
}