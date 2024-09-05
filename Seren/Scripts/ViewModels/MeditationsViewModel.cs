using System.Collections.ObjectModel;
using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.ViewModels;

public class MeditationsViewModel : BaseViewModel
{
    private readonly IRepository<Meditation> _meditationRepository;

    public ObservableCollection<MeditationViewModel> Meditations { get; set; }

    public MeditationsViewModel(IRepository<Meditation> meditationRepository)
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