using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreUI;
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public int score = 0;
    public bool pauseActive = false;

    private IAchievementService achievementService;

    void Start(){
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        achievementService = ServiceLocator.Current.Get<IAchievementService>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive == false)
            {
                Pause();
            } else
            {
                Resume();
            }
            
        }

        if (score >= 1000)
        {
            achievementService.UnlockAchievement(0);
        }

    }

    public void AsteroidDestroyed(Asteroid asteroid){
        if (asteroid.size < 0.75f){
            SetScore(score + 100);
        } else if (asteroid.size < 1.2f){
            SetScore(score + 50);
        } else {
            SetScore(score + 25);
        }
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreUI.text = "Score: " + score;
    }
    public void GameOver(){
        gameOverUI.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Asteroids");
    }

    public void Rewind(){
        
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        pauseActive = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        pauseActive = false;
    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }
}
