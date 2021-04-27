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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); 
    }

    public void SetMovementSpeed(float speed) { moveSpeed = speed; } 
}
