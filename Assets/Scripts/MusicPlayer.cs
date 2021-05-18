using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// The script is used to make music not to start from the very beging on every scene change.
/// Also allows to set music volume
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length > 1)
        {
            Destroy(this.gameObject);
            //return;
        }
        else
        {
            DontDestroyOnLoad(this);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = SettingController.GetVolumeValue();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
