using System;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    [SerializeField] private OldAchievement[] trophies;

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockAchievement(OldAchievement.AchievementTypes achievementType)
    {
        if (PlayerPrefs.GetInt(achievementType.ToString()) == 1)
            return;

        OldAchievement achievementToUnlock =
            Array.Find(trophies, dummyTrophy => dummyTrophy.GetAchievementType() == achievementType);

        if (achievementToUnlock == null)
        {
            Debug.LogWarning("Trophy not added with achievement: " + achievementType);
            return;
        }

        achievementToUnlock.UnlockThisAchievement();
    }
}