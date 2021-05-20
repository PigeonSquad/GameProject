using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;

    public Button loadGameButton;

    public Button exitGameButton;

    public string newGameScene;

    public GameObject loadFile;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Awake() {
        startGameButton.onClick.AddListener(NewGame);
        loadGameButton.onClick.AddListener(LoadGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void LoadGame()
    {
        loadFile.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
