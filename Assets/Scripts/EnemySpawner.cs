using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minTimeSpawner = 1f;
    [SerializeField] private float maxTimeSpawner = 5f;
    [SerializeField] private bool isSpawner = true;
    [SerializeField] private Attacker[] enemies;

    private IEnumerator Start()
    {
        while (isSpawner)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeSpawner, maxTimeSpawner));
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Attacker newAttacker = Instantiate(GetEnemy(), transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private Attacker GetEnemy()
    {
        return enemies[UnityEngine.Random.Range(0, enemies.Length)];
    }
}