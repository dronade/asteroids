using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreUI;
    public TMP_Text timeUI;
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public int score = 0;
    public bool pauseActive = false;
    public int time = 0;
    public bool hasDestroyed = false;
    public int _highScore;


    private IAchievementService achievementService;

    void Start(){
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        achievementService = ServiceLocator.Current.Get<IAchievementService>();
        StopCoroutine(Counter());
        StartCoroutine(Counter());
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

        DisplayTime(time);

        if (score >= 1000 && time <= 30)
        {
            achievementService.UnlockAchievement(0);
        }

        if (hasDestroyed = false && time <= 60)
        {
            achievementService.UnlockAchievement(1);
        }

        if(score >= 5000)
        {
            achievementService.UnlockAchievement(3);
        }

    }

    public void AsteroidDestroyed(Asteroid asteroid){
        hasDestroyed = true;
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


        if (score > PlayerPrefs.GetInt("Highscore", 0)){
            _highScore = score;
            // NOTE: need to change to not using playerprefs
            PlayerPrefs.SetInt("Highscore", _highScore);
        }
    }

    private IEnumerator Counter()
    {
        while (true)
        {
            time++;
            yield return new WaitForSeconds(1f);
        }
    }

    private void DisplayTime(int timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeUI.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GameOver(){
        gameOverUI.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Asteroids");
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
