using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreUI;
    public GameObject gameOverUI;
    public int score = 0;

    void Start(){
        gameOverUI.SetActive(false);
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
    public void gameOver(){
        gameOverUI.SetActive(true);
    }

    public void restart(){
        SceneManager.LoadScene(1);
    }
    public void rewind(){
        
    }
    public void mainMenu(){
        SceneManager.LoadScene(0);
    }
}
