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
        var entries = await _userCalendar.GetAllAsync();
        CalendarEntries = new ObservableCollection<UserCalendarEntry>(entries);
    }
}
