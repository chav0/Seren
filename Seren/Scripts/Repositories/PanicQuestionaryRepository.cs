using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class PanicQuestionaryRepository() : JsonRepository<PanicQuestion>(MeditationJsonPath), IPanicQuestionaryRepository
{
    private const string MeditationJsonPath = "questionary.json";
}