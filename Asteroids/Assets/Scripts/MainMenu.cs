using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// --------------------
// @Author Emily Canto
// --------------------

public class MainMenu : MonoBehaviour
{
   public void StartGame(){
        SceneManager.LoadScene("Asteroids");
   }

   public void QuitGame(){
        Application.Quit();
   }
}
