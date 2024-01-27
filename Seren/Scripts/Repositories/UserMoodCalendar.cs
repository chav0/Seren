using Seren.Scripts.Models;

namespace Seren.Scripts.Repositories;

public class UserMoodCalendar : IUserMoodCalendar
{
    public Dictionary<DateTime, UserMoodEntry> GetAll()
    {
        throw new NotImplementedException();
    }

    public UserMoodEntry GetByDate(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public void SetUserMood(DateTime dateTime, UserMoodEntry userMood)
    {
        throw new NotImplementedException();
    }
}