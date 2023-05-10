using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class MainMenu : MonoBehaviour
{

    public GameObject achUI;
    public GameObject leaderboardUI;
    public GameObject settingsUI;

    public void StartGame(){
        SceneManager.LoadScene("Asteroids");
        achUI.SetActive(false);
        leaderboardUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    public void QuitGame(){
        Application.Quit();
   }

    public void Achievements()
    {
        achUI.SetActive(true);
    }

    public void Leaderboard()
    {
        leaderboardUI.SetActive(true);
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
    }

    public void ExitUI()
    {
        achUI.SetActive(false);
        leaderboardUI.SetActive(false);
        settingsUI.SetActive(false);
    }
}
