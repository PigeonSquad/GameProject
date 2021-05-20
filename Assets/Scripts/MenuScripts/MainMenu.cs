using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void onPlayButtonClick()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   public void onQuitClick()
   {
       Debug.LogWarning("Game Closed");
       Application.Quit();
   }
   
}
