using Seren.Scripts.Models;

namespace Seren.Scripts.ViewModels;

public class MeditationViewModel : BaseViewModel
{
    public Meditation Meditation { get; }

    public string Header => Meditation.Header;
    public string Description => Meditation.Description;
    public string Duration => Meditation.Duration;

    public MeditationViewModel(Meditation meditation)
    {
        Meditation = meditation;
    }
}