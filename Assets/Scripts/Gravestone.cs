using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to specify gravestone defender, used to identify it.
/// Placed on gravestone
/// </summary>
public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if (attacker)
        {
            // do animation
        }
    }
}
