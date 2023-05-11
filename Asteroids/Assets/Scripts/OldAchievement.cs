using UnityEngine;
using UnityEngine.UI;

public class OldAchievement : MonoBehaviour
{
    private Image img;

    public enum AchievementTypes { highBall, dummy }

    [SerializeField] private AchievementTypes achievementType;

    [SerializeField] private string trophyName;
    [SerializeField] private string trophyDescription;

    private void Awake()
    {
        img = GetComponent<Image>();
        CheckIfAchievementIsUnlocked();
    }

    public AchievementTypes GetAchievementType()
    {
        return achievementType;
    }

    public void CheckIfAchievementIsUnlocked()
    {
        if (PlayerPrefs.GetInt(achievementType.ToString()) == 0)
        {
            img.color = Color.gray;
        }
        else
        {
            img.color = Color.white;
        }
    }

    public void UnlockThisAchievement()
    {
        PlayerPrefs.SetInt(achievementType.ToString(), 1);
        Awake();
    }
}