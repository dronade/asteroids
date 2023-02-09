using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void StartGame(){
        SceneManager.LoadScene(0);
   }

   public void QuitGame(){
        Application.Quit();
   }
}
