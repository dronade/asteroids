using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LocalAchievementService : IAchievementService
{

    private string _filePath = Application.persistentDataPath + "\\achievements.json";

    private AchievementArray _achievementsArray;

    public Achievement GetAchievement(int id)
    {
        return _achievementsArray.achievements[id];
    }

    public void LoadAchievements()
    {
        if (File.Exists(_filePath))
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();
                _achievementsArray = JsonUtility.FromJson<AchievementArray>(json);
            }
        }
        else
        {
            Achievement[] newAchievements =
            {
                new Achievement(0, "High Ball", "Get to 1000 points in under 30 seconds", false),
                new Achievement(1, "Pacifist?", "Survive for 1 minute without destroying an asteroid", false),
                new Achievement(2, "Temporal Rewind", "Rewind three times in a mission", false),
                new Achievement(3, "Bane of the Asteroids", "Score over 5,000 points!", false)
            };
            
            AchievementArray achievementArray = new AchievementArray(newAchievements);
            _achievementsArray = achievementArray;
            SaveAllAchievements();
        }
    }

    public void SaveAllAchievements()
    {
        string json = JsonUtility.ToJson(_achievementsArray);
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.Write(json);
        }
    }

    public void UnlockAchievement(int id)
    {
        if (!_achievementsArray.achievements[id].AchievementUnlocked) { 
            _achievementsArray.achievements[id].AchievementUnlocked = true;
            SaveAllAchievements();
        }
    }
}