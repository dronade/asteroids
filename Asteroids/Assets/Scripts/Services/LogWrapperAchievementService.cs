using UnityEngine;

public class LogWrapperAchievementService : IAchievementService
{
    IAchievementService _wrapped;

    public LogWrapperAchievementService(IAchievementService wrapped)
    {
        _wrapped = wrapped;
    }

    public Achievement GetAchievement(int id)
    {
        Debug.Log("Getting achievement " + id);
        return _wrapped.GetAchievement(id);
    }

    public void LoadAchievements()
    {
        Debug.Log("Loading achievements");
        _wrapped.LoadAchievements();
    }

    public void SaveAllAchievements()
    {
        Debug.Log("Saving all achievements");
        _wrapped.SaveAllAchievements();
    }

    public void UnlockAchievement(int id)
    {
        Debug.Log("Unlocking Achievement " + id);
        _wrapped.UnlockAchievement(id);
    }
}
