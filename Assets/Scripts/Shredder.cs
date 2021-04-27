using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to destroy projectiles that are out of the screen. Placed on the same called object.
/// </summary>
public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
