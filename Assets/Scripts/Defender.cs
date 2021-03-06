using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to store stars cost of a defender, it also has public method that allows to earn resources as
/// trophy animation event. Placed on all the defenders
/// </summary>
public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetStarCost() { return starCost; }

    // this method is for trophy, it is called as animation event, it allows us earn resources
    public void AddStars(int amount)
    {
        // getting StarsDisplay object, that stores amount of stars and add start to total amount
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }

}
