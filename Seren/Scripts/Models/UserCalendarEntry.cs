namespace Seren.Scripts.Models;

public class UserCalendarEntry : IIdentifiable
{
    public DateTime Date { get; set; }
    public PanicAttackLevel PanicAttackLevel { get; set; }
    public string Id => Date.ToShortDateString();
    
    public Color DayColor
    {
        get
        {
            if (Date.Date == DateTime.Today)
                return (Color)Application.Current.Resources["PrimaryTab2Color"];
            
            return (Color)Application.Current.Resources["TextColor"];
        }
    }
    
    public Color BackgroundColor
    {
        get
        {
            if (Date.Date == DateTime.Today + TimeSpan.FromDays(1))
                return (Color)Application.Current.Resources["Gray1"];
            
            if (Date.Date == DateTime.Today)
                return (Color)Application.Current.Resources["PrimaryTab2Color"];

            if (PanicAttackLevel != PanicAttackLevel.None)
                return (Color)Application.Current.Resources["PrimaryTab1Color"];
            
            return (Color)Application.Current.Resources["Gray2"];
        }
    }
    
    public Color TextColor
    {
        get
        {
            if (Date.Date == DateTime.Today + TimeSpan.FromDays(1))
                return (Color)Application.Current.Resources["Gray3"];
            
            if (Date.Date == DateTime.Today)
                return (Color)Application.Current.Resources["White"];

            if (PanicAttackLevel != PanicAttackLevel.None)
                return (Color)Application.Current.Resources["White"];

            return (Color)Application.Current.Resources["Gray4"];
        }
    }
}

public enum PanicAttackLevel
{
    None,
    Mild,
    Moderate,
    Severe,
    Extreme
}