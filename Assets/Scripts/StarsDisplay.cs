using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script is used to show amount of available start. It has functions to increase amount of start on stars earn and 
/// decrease stars when used buys a defender.
/// Placed on startText TMP in canvas.
/// </summary>
public class StarsDisplay : MonoBehaviour
{

    [SerializeField] int stars = 100;
    [SerializeField] TextMeshProUGUI starsText;

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starsText.text = stars.ToString();
    }

    // function that check if we have enough stars to place defender
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int amount) 
    { 
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        // if we have enought stars to buy a defenderS
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
