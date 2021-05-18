using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
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
