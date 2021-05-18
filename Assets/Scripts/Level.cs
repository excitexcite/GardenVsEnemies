using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    [SerializeField] Button[] levelButtons; // arrays of buttons references that allow to load selected level
    [SerializeField] int timeToWait = 4;
    [SerializeField] int levelAmount = 5;

    // static variables for storing next level's index to play
    public static string NEXT_LEVEL_KEY = "nextLevelToPlay";
    public static int LEVEL_TO_START = 1;

    // static variables for storing last played level index
    public static string LAST_LEVEL_KEY = "lastPlayedLevel";
    public static int LEVEL_TO_PLAY = 1;

    // statuc varuables for storing game over flag
    public static string GAME_COMPLETE_KEY = "gameComplete";
    // 0 means game is not complete, 1 - game complete
    public static int GAME_INCOMPLETE = 0;
    public static int GAME_COMPLETE = 1;

    private bool levelComplete = false;

    public void SetLevelCompleteOption(bool option) { levelComplete = option; }

    public int GetLevelAmount() { return levelAmount; }

    // function that is called when we successfully finish the last level in the game
    public void SetGameOverKey() { PlayerPrefs.SetInt(GAME_COMPLETE_KEY, GAME_COMPLETE); }

    // Start is called before the first frame update
    void Start()
    {
        EnableLevelLoadButtons();
    }

    private void EnableLevelLoadButtons()
    {
        // if level load buttons array was not assign in editor abort running this fuction
        if (levelButtons.Length == 0)
        {
            return;
        }
        // getting the number of last complete level
        int levelReached = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        Debug.Log("Level reached = " + levelReached);
        // making buttons for unreached levels unactive
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i >= levelReached)
            {
                Debug.Log("DIsable " + i + " Button");
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LoadLastPassedScene()
    {
        // check if the game is complete and load level selection scene if it is so
        // only this piece of code will be executed
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("LevelSelector");
            return;
        }
        // otherwise getting the next scene to load index
        int sceneToLoadIndex = PlayerPrefs.GetInt(LAST_LEVEL_KEY, LEVEL_TO_PLAY);
        // if index equals totalSceneNumber value plus one (the last level has be loaded), loading 
        // scene with index sceneToLoadIndex - 1
        if (sceneToLoadIndex == levelAmount + 1)
        {
            SceneManager.LoadScene(sceneToLoadIndex - 1);
        }
        // otherwise loading scene with index sceneToLoadIndex
        else
        {
            SceneManager.LoadScene(sceneToLoadIndex);
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        // check if the game is complete and load level selection scene if it is so
        // only this piece of code will be executed
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("LevelSelector");
            return;
        }
        // otherwise getting the next scene to load index and loading it
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastWrittenPrefs = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        if (sceneIndex >= lastWrittenPrefs)
        {
            Debug.Log("lastWrittenPrefs = " + lastWrittenPrefs);
            PlayerPrefs.SetInt(NEXT_LEVEL_KEY, sceneIndex + 1);
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelSelector");
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevelSelectorScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelector");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettingsScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
