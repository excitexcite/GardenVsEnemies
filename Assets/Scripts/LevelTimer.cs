using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// This script is uset to show timer. 00:00 on timer means that level is completed/
/// Placed on timer text/
/// </summary>
public class LevelTimer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] float time = 70f; // time on timer in seconds
    [SerializeField] float speed = 1f; // timer speed
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }

        time -= Time.deltaTime * speed; // decreasing timer
        string minutes = (((int)time / 60)).ToString("00"); // getting minutes, ex: 150s / 60 = 2
        string seconds = ((int)time % 60).ToString("00"); // getting seconds, ex: 150s % 60 = 30
        textMeshPro.text = minutes + ":" + seconds; // making whole timer number - 2:30
        // if the time is over 
        if (time <= 0f)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
