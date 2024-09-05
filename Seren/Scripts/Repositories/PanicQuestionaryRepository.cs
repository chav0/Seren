using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class PanicQuestionaryRepository() : JsonRepository<PanicQuestion>(QuestionaryJsonPath), IRepository<PanicQuestion>
{
    private const string QuestionaryJsonPath = "questionary.json";
}