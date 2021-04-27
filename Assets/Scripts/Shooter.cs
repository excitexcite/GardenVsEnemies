using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
