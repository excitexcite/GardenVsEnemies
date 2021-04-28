﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to create defenders on the screen. 
/// </summary>
public class DefenderSpawner : MonoBehaviour
{
    //at first has type GameObject, with creation of Defender script change type to Defender
    // same thing with SerializedField
    Defender defender; // defender prefab

    private void OnMouseDown()
    {
        Vector2 worldPos = GetSquareClicked();
        SpawnDefender(worldPos);
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // getting actual click position
        Debug.Log("X = " + clickPos.x.ToString() + ", Y = " + clickPos.y.ToString());
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); // transorm clickPos to world position; values that are on game field
        // squares
        Debug.Log("X = " + worldPos.x.ToString() + ", Y = " + worldPos.y.ToString());

        Vector2 gridPos = SnapToGrid(worldPos); // rounding position to place defender exactly in the center of the square
        return gridPos;
    }

    // function to round raw mouse click position to place defender exactly in the center of the square
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {

        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity);
    }

}
