using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to spawn attackers. 
/// </summary>
public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float mixSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.RandomRange(mixSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker =
            Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform; // making attacker child object of its` spawner
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
