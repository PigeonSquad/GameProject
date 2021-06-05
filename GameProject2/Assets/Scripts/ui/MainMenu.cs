using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public void onPlayButtonClick()
   {
      //Debug.LogWarning("entering next scene");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       
   }

   public void onQuitClick()
   {
       //Debug.LogWarning("Game Closed");
       Application.Quit();
   }
   
}
