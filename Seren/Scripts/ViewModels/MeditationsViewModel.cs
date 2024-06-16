using System.Collections.ObjectModel;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.ViewModels;

public class MeditationsViewModel : BaseViewModel
{
    private readonly IMeditationRepository _meditationRepository;

    public ObservableCollection<MeditationViewModel> Meditations { get; set; }

    public MeditationsViewModel(IMeditationRepository meditationRepository)
    {
        _meditationRepository = meditationRepository;
        Meditations = new ObservableCollection<MeditationViewModel>();
    }

    public async Task LoadMeditationsAsync()
    {
        var exercises = await _meditationRepository.GetAllAsync();
        Meditations.Clear();
        foreach (var exercise in exercises)
        {
            Meditations.Add(new MeditationViewModel(exercise));
        }
    }
}