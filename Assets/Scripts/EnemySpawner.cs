using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minTimeSpawner = 1f;
    [SerializeField] private float maxTimeSpawner = 5f;
    [SerializeField] private bool isSpawner = true;
    [SerializeField] private GameObject enemy;

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
        Instantiate(enemy, transform.position, transform.rotation);
    }
}