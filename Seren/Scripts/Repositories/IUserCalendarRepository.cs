using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IUserCalendarRepository
{
    Task<IEnumerable<UserCalendarEntry>> GetAllAsync();
    Task<UserCalendarEntry> GetByIdAsync(DateTime dateTime);
    Task SetByIdAsync(UserCalendarEntry userCalendar);
}