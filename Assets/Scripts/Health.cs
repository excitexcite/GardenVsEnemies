using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to represent attackers or defenders health. Placed on both of them.
/// </summary>
public class Health : MonoBehaviour
{

    [SerializeField] int health = 100;

    public int GetHealth() { return health; }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
