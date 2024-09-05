using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IUserCalendarRepository : IRepository<UserCalendarEntry>
{
    Task<UserCalendarEntry> GetByDateAsync(DateTime dateTime);
    Task SetByIdAsync(UserCalendarEntry userCalendar);
}