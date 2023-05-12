using System;

[Serializable]
public class AchievementArray
{
    public Achievement[] achievements;

    public AchievementArray(Achievement[] achievements)
    {
        this.achievements = achievements;
    }
}
