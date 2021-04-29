using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] AudioClip winSound;
    [SerializeField] float winSoundVolume = 0.5f;
    [SerializeField] float timeToLoad = 4f;
    int numberOfAttackers = 0;
    bool leveTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }

    public void AttackerSpawned() { numberOfAttackers++; }

    public void AttackerKilled() 
    { 
        numberOfAttackers--; 
        if (numberOfAttackers <= 0 && leveTimerFinished)
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
        winLabel.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
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
