using Seren.Scripts.Models;
using Seren.Scripts.Repositories;
using Seren.Scripts.Views;

namespace Seren.Scripts.ViewModels;

public class SurveyPageViewModel
{
    readonly IUserCalendarRepository _userCalendar;

    public SurveyPageViewModel(IUserCalendarRepository userCalendar)
    {
        _userCalendar = userCalendar;
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