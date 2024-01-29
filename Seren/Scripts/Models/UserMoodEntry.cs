namespace Seren.Scripts.Models;

public class UserMoodEntry : IIdentifiable
{
    public DateTime Date { get; set; }
    public Mood Mood { get; set; }
    public string Id => Date.ToShortDateString();
}

public enum Mood
{
    TheWorst = 0,
    Bad = 1,
    Normal = 2,
    Good = 3,
    Grate = 4
}