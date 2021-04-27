using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to create projectiles by defenders, placed on defenders
/// </summary>
public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    [SerializeField] float damage;

    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
    }

}
