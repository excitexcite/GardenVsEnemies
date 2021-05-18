using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This script is used to allow settings to change. Defines default setting values and allow to change them
/// via UI on setting screen.
/// </summary>
public class SettingController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] int defaultDifficulty= 0;

    public const string VOLUME_KEY = "volumeKey";
    public const string DIFFICULTY_KEY = "dificultyKey";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    private void Start()
    {
        volumeSlider.value = GetVolumeValue();
        difficultySlider.value = GetDifficultyValue();
    }

    private void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value); // this function call set the audio source volume
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

    public static void SetDifficultyValue(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            Debug.Log("Difficulty set to " + difficulty);
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Error while changing difficuty");
        }
    }

    public static int GetDifficultyValue()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY, MIN_DIFFICULTY);
    }

    public void SaveAndExit()
    {
        SetVolumeValue(volumeSlider.value);
        SetDifficultyValue((int)difficultySlider.value);
        FindObjectOfType<Level>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
