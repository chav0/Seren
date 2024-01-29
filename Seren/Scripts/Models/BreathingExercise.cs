namespace Seren.Scripts.Models;

public class BreathingExercise : IIdentifiable
{
    public string Id { get; set; }
    public List<BreathingPatternEntry> Patterns { get; set; }
}

public struct BreathingPatternEntry
{
    public float Time;
    public BreathType Type;
}

public enum BreathType
{
    Inhale,
    Exhale, 
    Hold
}