using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.ViewModels;

public class SurveyPageViewModel : BaseViewModel
{
    private readonly IUserCalendarRepository _userCalendar;
    private readonly IRepository<Meditation> _meditationRepository;

    public Task<Meditation> AntiPanicMeditation => _meditationRepository.GetByIdAsync("anti-panic");

    public SurveyPageViewModel(IUserCalendarRepository userCalendar, IRepository<Meditation> meditationRepository)
    {
        _userCalendar = userCalendar;
        _meditationRepository = meditationRepository;
    }
    
    public Task SaveResult(PanicAttackLevel panicAttackLevel)
    {
        return _userCalendar.SetByIdAsync(new UserCalendarEntry
        {
            Date = DateTime.Now,
            PanicAttackLevel = panicAttackLevel
        });
    }
}