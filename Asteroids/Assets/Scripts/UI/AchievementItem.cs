using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    [SerializeField] private int achievementID;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image image;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private Sprite lockedSprite;

    private void Start()
    {
        var achievementService = ServiceLocator.Current.Get<IAchievementService>();
        Achievement achievement = achievementService.GetAchievement(achievementID);

        titleText.SetText(achievement.AchievementName);
        descriptionText.SetText(achievement.AchievementDescription);

        if (achievement.AchievementUnlocked)
        {
            image.sprite = unlockedSprite;
        }
        else
        {
            image.sprite= lockedSprite;
        }
    }
}
