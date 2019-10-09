using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    [SerializeField] Attacker[] attackerArray;

    bool isSpwan = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (isSpwan)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay,maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawner()
    {
        isSpwan = false;
    }

    private void SpawnAttacker()
    {
        var index = Random.Range(0, attackerArray.Length);

        Spawn(attackerArray[index]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate
            (attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
