using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class MeditationRepository : JsonRepository<Meditation>, IMeditationRepository
{
    private const string MeditationJsonPath = "meditations.json";

    public MeditationRepository() : base(MeditationJsonPath)
    {
    }
}