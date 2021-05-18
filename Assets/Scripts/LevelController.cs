using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is used to controll level complete and level fail canvas on game scene.
/// Also used to turn on win sound on level complete condition.
/// The script also track the game over condition and sets appropriate flag when the game is completed
/// </summary>
public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject looseLabel;
    [SerializeField] AudioClip winSound;
    [SerializeField] float winSoundVolume = 0.5f;
    [SerializeField] float timeToLoad = 4f;
    int numberOfAttackers = 0;
    bool leveTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        looseLabel.SetActive(false);
    }

    public void AttackerSpawned() { numberOfAttackers++; }

    // function to check if there is no attackers
    public void AttackerKilled() 
    { 
        numberOfAttackers--; 
        if (numberOfAttackers <= 0 && leveTimerFinished && FindObjectOfType<LivesDisplay>().GetLive() > 0)
        {
            //StartCoroutine(HandleWinCondition());
            HandleWinCondition();
        }
    }

/*    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        yield return new WaitForSeconds(timeToLoad);
        FindObjectOfType<Level>().LoadNextScene();
    }*/

    // Identify if the game is overed (completed) and set appropriate flag to PlayerPrefs. Also 
    // load scene depending if game over condition is succed or not
    private void HandleWinCondition()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalLevelAmount = FindObjectOfType<Level>().GetLevelAmount();
        if (sceneIndex == totalLevelAmount)
        {
            SetGameCompleteOption();
        }
        winLabel.SetActive(true);
        if (PlayerPrefs.GetInt(Level.GAME_COMPLETE_KEY, Level.GAME_INCOMPLETE) == Level.GAME_INCOMPLETE)
        {
            PlayerPrefs.SetInt(Level.NEXT_LEVEL_KEY, sceneIndex + 1);
        }
       
        PlayerPrefs.SetInt(Level.LAST_LEVEL_KEY, sceneIndex + 1);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        Time.timeScale = 0;
    }

    private void SetGameCompleteOption()
    {
        PlayerPrefs.SetInt(Level.GAME_COMPLETE_KEY, Level.GAME_COMPLETE);
    }

    // makes level fail canvas active
    public void HandleLoseCondition()
    {
        looseLabel.SetActive(true);
        //AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() 
    { 
        leveTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
