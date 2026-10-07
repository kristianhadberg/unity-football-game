using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            return;
        }
        level2Button.interactable = GameState.GetLevelCompletedByName("Level1");
        level3Button.interactable = GameState.GetLevelCompletedByName("Level2");
        level4Button.interactable = GameState.GetLevelCompletedByName("Level3");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void PlayLevelTwo()
    {
        if (GameState.GetLevelCompletedByName("Level1"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    
    public void PlayLevelThree()
    {
        if (GameState.GetLevelCompletedByName("Level2"))
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void PlayLevelFour()
    {
        if (GameState.GetLevelCompletedByName("Level3"))
        {
            SceneManager.LoadScene("Level4");
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}
