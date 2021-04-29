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
    [SerializeField] Animator animator; // reference to defender`s animator to perform changing animations
    [SerializeField] float damage;
    AttackerSpawner currentLaneSpanwer;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            // Some Shoot Code
            //Debug.Log("Shoot pew-pew");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            // Not Shoot
            //Debug.Log("NOT SHOOT");
            animator.SetBool("IsAttacking", false);
        }
    }

    // fucntion that getting that spawner that is in the same lane with the defender
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>(); // getting all the spawner
        // iterate through spawners array to find the one which is in the same line
        foreach (AttackerSpawner spawner in spawners)
        {
            // the same line means the same Y cordinate
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                currentLaneSpanwer = spawner;
            }   
        }
    }

    // function that tell if there is a attacker in the spawner's line 
    private bool IsAttackerInLane()
    {
        if (currentLaneSpanwer.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab, gun.transform.position, Quaternion.identity);
    }

}
