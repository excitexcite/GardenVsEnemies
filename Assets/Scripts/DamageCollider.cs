using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to decrease players lives when attacker go out of the screen. Also destroys
/// attacker thar are out of the screen.
/// Placed on empty object out of the left screen side.
/// </summary>
public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
