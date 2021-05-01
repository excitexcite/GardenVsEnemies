using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int timeToWait = 4;
    [SerializeField] int levelAmount = 5;
    private int currentSceneIndex;

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

    public int GetLevelAmount() { return levelAmount; }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
