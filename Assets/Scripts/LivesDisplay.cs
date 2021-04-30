using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script is used to show, decrease player lives. When live equal zero, 
/// function to load LevelFail scene is called.
/// Placed on lives text.
/// </summary>
public class LivesDisplay : MonoBehaviour
{

    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    [SerializeField] TextMeshProUGUI textMeshPro;

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        textMeshPro.text = lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
