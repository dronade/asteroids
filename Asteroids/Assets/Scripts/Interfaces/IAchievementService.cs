public interface IAchievementService : IGameService
{
	void LoadAchievements();

	void SaveAllAchievements();

    void UnlockAchievement(int id);

	Achievement GetAchievement(int id);
}