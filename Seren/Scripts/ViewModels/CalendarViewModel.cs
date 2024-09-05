using System.Collections.ObjectModel;
using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.ViewModels;

public class CalendarViewModel : BaseViewModel
{
    private readonly IUserCalendarRepository _userCalendar;
    private ObservableCollection<UserCalendarEntry> _calendarEntries;

    public ObservableCollection<UserCalendarEntry> CalendarEntries
    {
        get => _calendarEntries;
        set => SetProperty(ref _calendarEntries, value);
    }

    public CalendarViewModel(IUserCalendarRepository userCalendar)
    {
        _userCalendar = userCalendar;
        LoadCalendarEntries();
    }

    private async void LoadCalendarEntries()
    {
        var entries = new List<UserCalendarEntry>(7);
        var today = DateTime.Today; 
        for (var i = 0; i < 7; i++)
        {
            var time = today - TimeSpan.FromDays(7 - i - 2);
            var foundEntry = await _userCalendar.GetByDateAsync(time);
            entries.Add(foundEntry);
        }
        CalendarEntries = new ObservableCollection<UserCalendarEntry>(entries);
    }
}
