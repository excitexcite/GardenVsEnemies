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

    // Update is called once per frame
    void Update()
    {
        starsText.text = stars.ToString();
    }

    public void AddStars(int amount) { stars += amount; }

    public void SpendStars(int amount)
    {
        // if we have enought stars to buy a defenderS
        if (stars >= amount)
        {
            stars -= amount;
        }
    }

}
