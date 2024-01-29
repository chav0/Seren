using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IUserMoodCalendarRepository
{
    Task<IEnumerable<UserMoodEntry>> GetAllAsync();
    Task<UserMoodEntry> GetByIdAsync(DateTime dateTime);
    Task SetByIdAsync(UserMoodEntry userMood);
}