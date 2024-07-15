using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.Services;

public class UserCalendarRepository : SecureDataRepository<UserCalendarEntry>, IUserCalendarRepository
{
    private const string CalendarPath = "calendar";

    public UserCalendarRepository() : base(CalendarPath)
    {
    }

    public async Task<UserCalendarEntry> GetByIdAsync(DateTime dateTime)
    {
        var entry = await GetByIdAsync(dateTime.ToShortDateString()) ?? new UserCalendarEntry
        {
            Date = dateTime.Date,
            PanicAttackLevel = PanicAttackLevel.None
        };

        return entry;
    }

    public Task SetByIdAsync(UserCalendarEntry userCalendar) => SetByIdAsync(userCalendar.Id, userCalendar);
}

public class FakeUserCalendarRepository : IUserCalendarRepository
{
    private List<UserCalendarEntry> _calendarEntries = new()
    {
        new UserCalendarEntry { Date = new DateTime(2024, 6, 1), PanicAttackLevel = PanicAttackLevel.None },
        new UserCalendarEntry { Date = new DateTime(2024, 6, 2), PanicAttackLevel = PanicAttackLevel.Mild },
        new UserCalendarEntry { Date = new DateTime(2024, 6, 4), PanicAttackLevel = PanicAttackLevel.Moderate },
        new UserCalendarEntry { Date = new DateTime(2024, 6, 6), PanicAttackLevel = PanicAttackLevel.Severe },
        new UserCalendarEntry { Date = new DateTime(2024, 6, 7), PanicAttackLevel = PanicAttackLevel.Moderate },
        new UserCalendarEntry { Date = new DateTime(2024, 6, 8), PanicAttackLevel = PanicAttackLevel.Moderate },
    };
    
    public Task<IEnumerable<UserCalendarEntry>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<UserCalendarEntry>>(_calendarEntries);
    }

    public Task<UserCalendarEntry> GetByIdAsync(DateTime dateTime)
    {
        var entry = _calendarEntries.FirstOrDefault(e => e.Date.Date == dateTime.Date);
        if (entry == null)
            entry = new UserCalendarEntry
            {
                Date = dateTime.Date,
                PanicAttackLevel = PanicAttackLevel.None
            };
        
        return Task.FromResult(entry);
    }

    public Task SetByIdAsync(UserCalendarEntry userCalendar)
    {
        var existingEntry = _calendarEntries.FirstOrDefault(e => e.Date.Date == userCalendar.Date.Date);
        if (existingEntry != null)
        {
            existingEntry.PanicAttackLevel = userCalendar.PanicAttackLevel;
        }
        else
        {
            _calendarEntries.Add(userCalendar);
        }
        return Task.CompletedTask;
    }
}