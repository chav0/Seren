namespace Seren.Scripts.Models;

public class BreathingExercise : IIdentifiable
{
    public string Id { get; set; }
    public List<BreathingPatternEntry> Pattern { get; set; }
}

public struct BreathingPatternEntry
{
    public float Delay;
    public float Time;
    public BreathType Type;
}

public enum BreathType
{
    BreathIn,
    BreathOut
}