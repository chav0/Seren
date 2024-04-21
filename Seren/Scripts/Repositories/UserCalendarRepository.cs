using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.Services;

public class UserCalendarRepository : SecureDataRepository<UserCalendarEntry>, IUserCalendarRepository
{
    private const string CalendarPath = "calendar";

    public UserCalendarRepository() : base(CalendarPath)
    {
    }

    public Task<UserCalendarEntry> GetByIdAsync(DateTime dateTime) => GetByIdAsync(dateTime.ToShortDateString());

    public Task SetByIdAsync(UserCalendarEntry userCalendar) => SetByIdAsync(userCalendar.Id, userCalendar);
}