using System;

[Serializable]
public class Achievement
{
    public int AchievementID;
    public string AchievementName;
    public string AchievementDescription;
    public bool AchievementUnlocked;

    public Achievement(int AchievementID, string AchievementName, string AchievementDescription, bool AchievementUnlocked)
    {
        this.AchievementID = AchievementID;
        this.AchievementName = AchievementName;
        this.AchievementDescription = AchievementDescription;
        this.AchievementUnlocked = AchievementUnlocked;
    }
}