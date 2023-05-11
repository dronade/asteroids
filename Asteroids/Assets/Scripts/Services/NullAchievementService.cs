public class NullAchievementService : IAchievementService
{
    public Achievement GetAchievement(int id)
    {
        return null;
    }

    public void LoadAchievements()
    {
        // 
    }

    public void SaveAllAchievements()
    {
        // 
    }

    public void UnlockAchievement(int id)
    {
        // 
    }
}