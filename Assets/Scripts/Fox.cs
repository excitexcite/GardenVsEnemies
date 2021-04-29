using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to specify fox attacker. Has functionality that allows fox to jump over the 
/// stones (via animation).
/// Placed on fox attacker
/// </summary>
public class Fox : MonoBehaviour
{
    // fox has a collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // getting the object which fox collides to
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        // checking if the object has Defender component (otherwise the object is projectile or something other)
        else if (otherObject.GetComponent<Defender>())
        {
            // tells the Attacker script to start attacking the defender
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
