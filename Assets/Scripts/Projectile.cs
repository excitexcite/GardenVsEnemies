using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scripts is used to perform projectile movment, it also contains projectile damage.
/// Placed on projectile.
/// </summary>
public class Projectile : MonoBehaviour
{

    [SerializeField] int damage = 100;
    [SerializeField] float projectileSpeed = 1f;

    public int GetDamage() { return damage; }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(damage);
            DestroyProjectile();
        }

    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

}
