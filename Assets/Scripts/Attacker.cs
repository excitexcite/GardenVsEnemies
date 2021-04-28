using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script is used to make attackers move. It also changes move speed throught animation events 
///  to play animation correctly. Placed on attackers.
/// </summary>
public class Attacker : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Animator animator;
    GameObject currentTarget;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        UpdateAnimationState(); // checking for the moment when attacker killed the target
    }

    // fuction that change animation from attack to walk when attacker has killed the target
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    // function that allows attack the defender, this function call is placed in lizard (other other
    // named scripts) script
    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true); // starting attack animation
        currentTarget = target; // setting attack target to the particular defender
    }

    // fuction that allow to deal damage to defenders
    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) { return; }
        // getting defender's health component
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage); // dealing damage
        }
    }

    public void SetMovementSpeed(float speed) { moveSpeed = speed; } 
}
