using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to represent lizard attacker. Placed on lizard
/// </summary>
public class Lizard : MonoBehaviour
{
    // lizard has a collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // getting the object which lizard collides to
        GameObject otherObject = otherCollider.gameObject;
        // checking if the object has Defender component (otherwise the object is projectile or something other)
        if (otherObject.GetComponent<Defender>())
        {
            // tells the Attacker script to start attacking the defender
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
