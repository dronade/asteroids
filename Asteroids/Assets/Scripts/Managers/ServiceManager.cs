using UnityEngine;

public class ServiceManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Initialize();

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("loading achievement service");
            LocalAchievementService localAchievementService = new LocalAchievementService();
            LogWrapperAchievementService logWrapperAchievementService = new LogWrapperAchievementService(localAchievementService);
            ServiceLocator.Current.Register<IAchievementService>(logWrapperAchievementService);
            ServiceLocator.Current.Get<IAchievementService>().LoadAchievements();
        } else
        {
            NullAchievementService nullAchievementService = new NullAchievementService();
            LogWrapperAchievementService logWrapperAchievementService = new LogWrapperAchievementService(nullAchievementService);
            ServiceLocator.Current.Register<IAchievementService>(logWrapperAchievementService);
        }
    }
}
