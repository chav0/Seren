using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public interface IUserMoodCalendar
{
    Dictionary<DateTime, UserMoodEntry> GetAll();
    UserMoodEntry GetByDate(DateTime dateTime);
    void SetUserMood(DateTime dateTime, UserMoodEntry userMood);
}