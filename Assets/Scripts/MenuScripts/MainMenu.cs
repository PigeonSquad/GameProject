using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagment;
public class MainMenu : MonoBehaviour
{
   public void onPlayButtonClick()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScreen().buildIndex+1);
   }
   
}
