using Seren.Scripts.Models;
using Seren.Scripts.Repositories;

namespace Seren.Scripts.Services;

public class UserMoodCalendarRepository : SecureDataRepository<UserMoodEntry>, IUserMoodCalendarRepository
{
    private const string CalendarPath = "calendar";

    protected UserMoodCalendarRepository() : base(CalendarPath)
    {
    }

    public Task<UserMoodEntry> GetByIdAsync(DateTime dateTime) => GetByIdAsync(dateTime.ToShortDateString());

    public Task SetByIdAsync(UserMoodEntry userMood) => SetByIdAsync(userMood.Id, userMood);
}