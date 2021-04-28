using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change color (look like they become active)
/// on defenders exaples (buttons) when player click on them. Placed on each defender button
/// </summary>
public class DefenderButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        // iterate through all buttons for defender creation
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        // make selected one white (active)
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
