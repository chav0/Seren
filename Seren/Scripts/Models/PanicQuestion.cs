namespace Seren.Scripts.Models;

public class PanicQuestion : IIdentifiable
{
    public string Id { get; set; }
    public string LocalizationKey { get; set; }
    public int NoAnswer { get; set; }
    public int YesAnswer { get; set; }
}