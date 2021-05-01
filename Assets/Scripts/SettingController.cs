using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    public const string VOLUME_KEY = "volumeKey";
    public const string DIFICULTY_KEY = "fidicultyKey";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    private void Start()
    {
        volumeSlider.value = GetVolumeValue();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value); // this functin call set audio source volume
        }
        else
        {
            Debug.LogWarning("No music player found... kind of an error!");
        }
    }

    public static void SetVolumeValue(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Volume set to " + volume);
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Error while changing volume");
        }
    }
    
    public static float GetVolumeValue()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY, MIN_VOLUME); 
    }


    public void SaveAndExit()
    {
        SetVolumeValue(volumeSlider.value);
        FindObjectOfType<Level>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
