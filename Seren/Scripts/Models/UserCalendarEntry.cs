namespace Seren.Scripts.Models;

public class UserCalendarEntry : IIdentifiable
{
    public DateTime Date { get; set; }
    public PanicAttackLevel PanicAttackLevel { get; set; }
    public string Id => Date.ToShortDateString();
}

public enum PanicAttackLevel
{
    None,
    Mild,
    Moderate,
    Severe,
    Extreme
}