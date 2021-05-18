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
    [SerializeField] Attacker[] attackerPrefabArray;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(mixSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker =
           Instantiate(myAttacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform; // making attacker child object of its` spawner
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

}
