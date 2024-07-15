namespace Seren.Scripts.Models;

public class BreathingExercise : IIdentifiable
{
    public string Id { get; set; }
    public string Header { get; set; }
    public string FullImagePath { get; set; }
    public int Count { get; set; }
    public List<BreathingPatternEntry> Patterns { get; set; }
}

public struct BreathingPatternEntry
{
    public float Time { get; set; }
    public BreathType Type { get; set; }
}

public enum BreathType
{
    Inhale,
    Exhale, 
    Hold
}