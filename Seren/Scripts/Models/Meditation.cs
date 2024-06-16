namespace Seren.Scripts.Models;

public class Meditation : IIdentifiable
{
    public string Id { get; set; }
    public string Header { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public string AudioUrl { get; set; }
}