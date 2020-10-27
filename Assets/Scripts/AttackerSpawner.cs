using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minimumSpawnDelay = 1.0f;
    [SerializeField] float maximumSpawnDelay = 5.0f;
    [SerializeField] Attacker[] attackerPrefabs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minimumSpawnDelay, maximumSpawnDelay));

            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        if (!spawn)
        {
            return;
        }

        Attacker attackerToSpawn = attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];

        Spawn(attackerToSpawn);
    }

    private void Spawn(Attacker attackerToSpawn)
    {
        Attacker newAttacker = Instantiate(
            attackerToSpawn,
            transform.position,
            transform.rotation
        ) as Attacker;

        newAttacker.transform.parent = transform;
    }
}
